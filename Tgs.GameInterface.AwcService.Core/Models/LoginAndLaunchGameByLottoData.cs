using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tgs.GameInterface.AwcService.Core.Models
{
    public record LoginAndLaunchGameByLottoData
    {
        /// <summary>
        /// The player code
        /// </summary>
        public string PlayerCode { get; set; } = default!;
        /// <summary>
        /// 系统会自动检测玩家的装置; 也可明确标示true，false来强制选择玩家是否使用行动版画面.
        /// </summary>
        public bool IsMobileLogin { get; set; }
        /// <summary>
        /// Gets the external URL.
        /// </summary>
        public string ExternalURL { get; set; } = default!;
        /// <summary>
        /// 游戏平台名称.
        /// </summary>
        public string Platform { get; set; } = default!;
        /// <summary>
        /// Default is English预设为英文.
        /// </summary>
        public string Language { get; set; } = "en";
    }
}
