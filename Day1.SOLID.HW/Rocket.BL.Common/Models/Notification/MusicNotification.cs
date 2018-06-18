using System;
using System.Collections.Generic;
using Rocket.BL.Common.Models.ReleaseList;

namespace Rocket.BL.Common.Models.Notification
{
    /// <summary>
    /// Описывает музыкальный релиз для целей нотификации
    /// </summary>
    public class MusicNotification : BaseInfoNotification
    {
        /// <summary>
        /// Возвращает или задает коллекцию получателей сообщений
        /// </summary>
        public ICollection<Receiver> Receivers { get; set; }

        /// <summary>
        /// Возвращает или задает исполнителей музыкального релиза
        /// </summary>
        public IList<Musician> Musicians { get; set; }
    }
}