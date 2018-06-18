using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rocket.BL.Common.Models.Notification
{
    /// <summary>
    /// Base class for info about release content
    /// </summary>
    public abstract class BaseInfoNotification
    {
        /// <summary>
        /// Identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name content
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Date release
        /// </summary>
        public DateTime ReleaseDate { get; set; }
    }
}
