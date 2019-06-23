let ffmeg=require("ffmpeg");
module.exports= function (callback,videoPath,outPath, videoFormat) {
    console.log("nksannkans");
    let processs =new ffmeg(videoPath);
    processs.then(function (video) {
        video
            //.setVideoFormat(videoFormat) 
            .setVideoCodec("h264") 
            .save(outPath);
        callback(null,"video created");
    });
    
    
};
//convertVideo("C:\\Users\\OMEN15\\projects\\personal_projects\\VueChatApp\\Uploads\\Videos\\83879b7c-e041-4d25-8f47-64725dc090273fa9dbbd-904f-42f0-b8e1-0bf3dc0bf680.mp4","dnksdnskdkns.mp4","mp4");
