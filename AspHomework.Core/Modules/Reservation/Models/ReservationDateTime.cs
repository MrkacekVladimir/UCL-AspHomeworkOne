using System;
namespace AspHomework.Core.Modules.Reservation.Models
{
    /// <summary>
    /// Reservation date time.
    /// </summary>
    public class ReservationDateTime
    {    
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:AspHomework.Core.Modules.Reservation.Models.ReservationDateTime"/> class.
        /// </summary>
        /// <param name="dateFrom">Date from.</param>
        /// <param name="isAvailable">If set to <c>true</c> is available.</param>
        public ReservationDateTime(DateTime dateFrom, bool isAvailable)
        {
            From = dateFrom;
            //Reservation dates are fixed to one hour.
            Until = dateFrom.AddHours(1);
            IsAvailable = isAvailable;
        }
        /// <summary>
        /// Gets FROM date value.
        /// </summary>
        /// <value>From.</value>
        public DateTime From { get; private set; }
        /// <summary>
        /// Gets the UNTIL date value.
        /// </summary>
        /// <value>The until.</value>
        public DateTime Until { get; private set; }
        /// <summary>
        /// Gets a value indicating whether this date is available.
        /// </summary>
        /// <value><c>true</c> if is available; otherwise, <c>false</c>.</value>
        public bool IsAvailable { get; private set; }
    }
}
