using System;

namespace Logic.ViewModels.Client
{
    public class RideViewModel
    {
        /// <summary>
        /// Godzina odjazdu autobusu
        /// </summary>
        public DateTime RideTime { get; set; }

        /// <summary>
        /// Nazwa linii
        /// </summary>
        public string LineName { get; set; }

        /// <summary>
        /// Liczba dostêpnych miejsc
        /// </summary>
        public int AvailableSeats { get; set; }

        /// <summary>
        /// Cena za przejazd
        /// </summary>
        public decimal FinalPrice { get; set; }

        /// <summary>
        /// D³ugoœæ trasy
        /// </summary>
        public int FinalDistance { get; set; }

        /// <summary>
        /// Czas przejazdu
        /// </summary>
        public TimeSpan FinalTime { get; set; }

    }
}