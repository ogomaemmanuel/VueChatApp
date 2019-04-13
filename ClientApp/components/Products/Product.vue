<template>
    <tr>
        <td class="action-left">
            <div>
                <input
                        class="selector"
                        type="checkbox">
                <span>
          <i class="fa fa-power-off"></i>
        </span>
            </div>
        </td>
        <td>
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa, officiis.
        </td>
        <td>Lorem ipsum dolor sit amet.</td>
        <td>200</td>
        <td>Lorem.</td>
        <td>Ksh 4000</td>
        <td class="block-row">50</td>
        <td class="action-right">
      <span>
        <i class="fa fa-trash"></i>
      </span>
        </td>
    </tr>
</template>

<style lang="scss">
    .action-right {
        span {
            border-left-style: dotted;
            padding-left: 5px;
        }
    }

    .action-left {
        div {
            display: inline-flex;
            align-items: center;
            height: 100%;

            .selector {
                margin-right: 5px;
            }

            span {
                border-left-style: solid;
                border-right-style: dotted;
                padding-left: 5px;
                padding-right: 5px;
            }
        }
    }
</style>