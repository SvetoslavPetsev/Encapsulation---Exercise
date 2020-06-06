namespace P05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private double rating;

        public Team(string name)
        {
            this.Name = name;
            this.Players = new HashSet<Player>();
        }
        public HashSet<Player> Players { get; }
        public string Name 
        { 
            get 
            {
                return this.name;
            } 
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            } 
        }
        public double Rating
        {
            get 
            {
                this.rating = 0;
                if (this.Players.Any())
                {
                    double avg = this.rating;
                    foreach (var player in this.Players)
                    {
                        avg += player.Stats.AverangeStats();
                    }
                    this.rating = Math.Round(avg / this.Players.Count);
                }
                return this.rating;
            }
         }
        public int NumberOfPlayers 
        {
            get 
            {
                return this.Players.Count;
            }
        }
        public void AddPlayer(Player player)
        {
            this.Players.Add(player);
        }
        public void RemovePlayer(string name)
        {
            if (!this.Players.Any(x => x.Name == name))
            {
                throw new ArgumentException($"Player{name} is not in {this.name} team.");
            }
            var targetPlayer = this.Players.FirstOrDefault(x => x.Name == name);
            this.Players.Remove(targetPlayer);
        }
    }
}
