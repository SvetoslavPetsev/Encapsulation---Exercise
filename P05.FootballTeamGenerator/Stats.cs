using System;

namespace P05.FootballTeamGenerator
{
    public class Stats
    {
        private int MIN_STAT_VALUE = 0;
        private int MAX_STAT_VALUE = 100;
        private string EXCEPTION_MESSAGE = " should be between 0 and 100.";

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance 
        {
            get 
            {
                return this.endurance;
            }
            private set 
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException("Endurance" + EXCEPTION_MESSAGE);
                }
                this.endurance = value;
            } 
        }

        public int Sprint 
        {
            get 
            {
                return this.sprint;
            } 
            private set 
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException("Sprint" + EXCEPTION_MESSAGE);
                }
                this.sprint = value;
            } 
        }

        public int Dribble 
        {
            get 
            {
                return this.dribble;
            } 
            private set 
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException("Dribble" + EXCEPTION_MESSAGE);
                }
                this.dribble = value;
            } 
        }

        public int Passing 
        { 
            get 
            {
                return this.passing;
            } 
            private set 
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException("Passing" + EXCEPTION_MESSAGE);
                }
                this.passing = value;
            } 
        }

        public int Shooting 
        {
            get 
            {
                return this.shooting;
            } 
            
            private set 
            {
                if (!IsValidStat(value))
                {
                    throw new ArgumentException("Shoting" + EXCEPTION_MESSAGE);
                }
                this.shooting = value;
            }    
        }

        public double AverangeStats()
        {
            return (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
        }
        private bool IsValidStat(int status)
        {
            return status >= MIN_STAT_VALUE && status <= MAX_STAT_VALUE;
        }
    }
}
