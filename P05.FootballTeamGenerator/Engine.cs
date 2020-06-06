namespace P05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public HashSet<Team> teamList { get; private set; }
        public Engine()
        {
            this.teamList = new HashSet<Team>();
        }
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmd = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                    if (cmd[0] == "Team")
                    {
                        string teamName = cmd[1];
                        if (!IsValidTeam(teamName))
                        {
                            this.teamList.Add(new Team(teamName));
                        }
                    }
                    else if (cmd[0] == "Add")
                    {
                        string teamName = cmd[1];

                        if (!IsValidTeam(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        string playerName = cmd[2];
                        int endurance = int.Parse(cmd[3]);
                        int sprint = int.Parse(cmd[4]);
                        int dribble = int.Parse(cmd[5]);
                        int passing = int.Parse(cmd[6]);
                        int shoting = int.Parse(cmd[7]);

                        Stats stats = new Stats(endurance, sprint, dribble, passing, shoting);
                        Player player = new Player(playerName, stats);
                        this.teamList.FirstOrDefault(x => x.Name == teamName).AddPlayer(player);
                    }
                    else if (cmd[0] == "Remove")
                    {
                        string teamName = cmd[1];

                        if (!IsValidTeam(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }

                        string playerName = cmd[2];

                        if (!this.teamList.FirstOrDefault(x => x.Name == teamName).Players.Any(p => p.Name == playerName))
                        {
                            throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
                        }

                        this.teamList.FirstOrDefault(x => x.Name == teamName).RemovePlayer(playerName);
                    }
                    else if (cmd[0] == "Rating")
                    {
                        string teamName = cmd[1];
                        if (!IsValidTeam(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        double rating = this.teamList.FirstOrDefault(x => x.Name == teamName).Rating;
                        Console.WriteLine($"{teamName} - {rating}");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
        public bool IsValidTeam(string name)
        {
            return this.teamList.Any(x => x.Name == name);
        }
    }
}
