const path = require("path");
const webpack = require("webpack");
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const bundleOutputDir = "./wwwroot/dist";
const UglifyJSPlugin = require('uglifyjs-webpack-plugin');

module.exports = env => {
  const isDevBuild = !(env && env.prod)

  return [
    {
      stats: { modules: false },
      context: __dirname,
      resolve: { extensions: [".js",".vue",".css",".scss",".sass"] },
      entry: { main: "./ClientApp/boot.js" },
      module: {
        rules: [
          {
            test: /\.vue$/,
            include: /ClientApp/,
            loader: "vue-loader",
            options: {
              loaders: {
                // Since sass-loader (weirdly) has SCSS as its default parse mode, we map
                // the "scss" and "sass" values for the lang attribute to the right configs here.
                // other preprocessors should work out of the box, no loader config like this necessary.
                scss: "vue-style-loader!css-loader!sass-loader",
                sass: "vue-style-loader!css-loader!sass-loader?indentedSyntax"
              }
              // other vue-loader options go here
            }
          },
          {
            test: /\.css$/,
            use: isDevBuild
              ? ["style-loader", "css-loader"]
              : ExtractTextPlugin.extract({ use: "css-loader?minimize" })
          },
          {  test: /.(png|jpg|jpeg|gif|svg|woff|woff2|ttf|eot)$/, use: "url-loader?limit=100000" }
        ]
      },
      output: {
        path: path.join(__dirname, bundleOutputDir),
        filename: "[name].js",
        publicPath: "dist/"
      },
      plugins: [
        new webpack.DefinePlugin({
          "process.env": {
            NODE_ENV: JSON.stringify(isDevBuild ? "development" : "production")
          }
        }),
        new webpack.DllReferencePlugin({
          context: __dirname,
          manifest: require("./wwwroot/dist/vendor-manifest.json")
        })
      ].concat(
        isDevBuild
          ? [
              // Plugins that apply in development builds only
              new webpack.SourceMapDevToolPlugin({
                filename: "[file].map", // Remove this line if you prefer inline source maps
                moduleFilenameTemplate: path.relative(
                  bundleOutputDir,
                  "[resourcePath]"
                ) // Point sourcemap entries to the original file locations on disk
              })
            ]
          : [
              // Plugins that apply in production builds only
              new UglifyJSPlugin(),
              new ExtractTextPlugin("site.css")
            ]
      )
    }
  ]
}
