using System;

namespace Logic.ViewModels.Client
{
    public class RideViewModel
    {
        /// <summary>
        /// Id przejazdu
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Godzina odjazdu autobusu
        /// </summary>
        public DateTime RideTime { get; set; }

        /// <summary>
        /// Nazwa linii
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// Liczba dost�pnych miejsc
        /// </summary>
        public int AvailableSeats { get; set; }

        /// <summary>
        /// Cena za przejazd
        /// </summary>
        public decimal FinalPrice { get; set; }

        /// <summary>
        /// D�ugo�� trasy
        /// </summary>
        public int FinalDistance { get; set; }

        /// <summary>
        /// Czas przejazdu
        /// </summary>
        public TimeSpan FinalTime { get; set; }

    }
}