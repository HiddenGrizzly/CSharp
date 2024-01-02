using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vleague
{
    public class Match
    {
        private Team teamManager = new Team();
        public void CreateNewMatch(List<Match> matches, List<Team> teams)
        {
            Console.WriteLine("=====Tạo lịch thi đấu=======");

            teamManager.ViewTeams(teams);

            Console.Write("Chọn đội 1 (nhập STT): ");
            int team1Index = int.Parse(Console.ReadLine()) - 1;

            Console.Write("Chọn đội 2 (nhập STT): ");
            int team2Index = int.Parse(Console.ReadLine()) - 1;

            if (team1Index >= 0 && team1Index < teams.Count &&
                team2Index >= 0 && team2Index < teams.Count && team1Index != team2Index)
            {
                Team team1 = teams[team1Index];
                Team team2 = teams[team2Index];

                Console.Write($"Trận: {team1.TeamName} vs {team2.TeamName}");

                Console.Write($"Ngày thi đấu: ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write($"Giờ thi đấu: ");
                TimeSpan time = TimeSpan.Parse(Console.ReadLine());

                Console.Write($"Sân thi đấu: ");
                string stadium = Console.ReadLine();

                Match newMatch = new Match { Team1 = team1, Team2 = team2, Date = date, Time = time, Stadium = stadium };

                Console.Write($"Bạn muốn cập nhật?(Y/N) ");
                string choose = Console.ReadLine();
                bool flag = true;
                while (flag) 
                {
                   if (choose == "Y") 
                    {
                        matches.Add(newMatch);
                        Console.WriteLine("Thêm trận thành công!");
                        flag = false;
                    }
                    else if (choose == "N") 
                    {
                        Console.WriteLine("Ngừng cập nhật lịch thi đấu!");
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Chọn sai định dạng");
                    }
                }
            }
            else
            {
                Console.WriteLine("Chọn sai đội.");
            }
        }

        public void ViewSchedule(List<Match> matches)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("| STT | Trận                     | Ngày       | Giờ    | Sân        |");
            Console.WriteLine("=================================");

            for (int i = 0; i < matches.Count; i++)
            {
                Console.WriteLine($"| {i + 1,-4} | {matches[i].Team1.TeamName,-24} vs {matches[i].Team2.TeamName,-15} | " +
                              $"{matches[i].Date,-10} | {matches[i].Time,-6} | {matches[i].Stadium,-10} |");
            }
            Console.WriteLine("=================================");
        }

        public void UpdateMatchInformation(List<Match> matches)
        {
            ViewSchedule(matches);

            Console.Write("Chọn trận để cập nhật (Nhập STT): ");
            int matchIndex = int.Parse(Console.ReadLine()) - 1;

            if (matchIndex >= 0 && matchIndex < matches.Count)
            {
                Console.Write("Cập nhật ngày: ");
                matches[matchIndex].Date = DateTime.Parse(Console.ReadLine());

                Console.Write("Cập nhật giờ: ");
                matches[matchIndex].Time = TimeSpan.Parse(Console.ReadLine());

                Console.Write("Cập nhật sân: ");
                matches[matchIndex].Stadium = Console.ReadLine();

                Console.WriteLine("Cập nhật trận thành công!");
            }
            else
            {
                Console.WriteLine("Chọn sai trận.");
            }
        }

        public void ViewMatchResult(List<Match> matches)
        {
            Console.WriteLine("=========Kết quả thi đấu=========");

            for (int i = 0; i < matches.Count; i++)
            {
                Console.WriteLine($"| {i + 1,-4} | {matches[i].Team1.TeamName,-24} {matches[i].GoalsTeam1} vs {matches[i].GoalsTeam2} {matches[i].Team2.TeamName,-15} |");
            }
            Console.WriteLine("=================================");
        }
        public void UpdateMatchResult(List<Match> matches)
        {
            ViewMatchResult(matches);

            Console.Write("Chọn trận để cập nhật (Nhập STT): ");
            int matchIndex = int.Parse(Console.ReadLine()) - 1;

            if (matchIndex >= 0 && matchIndex < matches.Count)
            {
                Console.Write($"{matches[matchIndex].Team1.TeamName,-24}");
                matches[matchIndex].GoalsTeam1 = int.Parse(Console.ReadLine());

                Console.Write($"{matches[matchIndex].Team1.TeamName,-15}");
                matches[matchIndex].GoalsTeam2 = int.Parse(Console.ReadLine());
                int goalsTeam1 = matches[matchIndex].GoalsTeam1;
                int goalsTeam2 = matches[matchIndex].GoalsTeam2;
                UpdateTeamStatistics(matches[matchIndex].Team1, goalsTeam1, goalsTeam2);
                UpdateTeamStatistics(matches[matchIndex].Team2, goalsTeam2, goalsTeam1);
                Console.WriteLine("Cập nhật trận thành công!");
            }
            else
            {
                Console.WriteLine("Chọn sai trận.");
            }
        }
        public void UpdateTeamStatistics(Team team, int goalsFor, int goalsAgainst)
        {
            team.MatchesPlayed++;

            if (goalsFor > goalsAgainst)
            {
                team.Wins++;
            }
            else if (goalsFor < goalsAgainst)
            {
                team.Losses++;
            }
            else
            {
                team.Draws++;
            }
        }
        public Team Team1 {get; set;}
        public Team Team2 {get; set;}
        public DateTime Date {get; set;}
        public TimeSpan Time {get; set;}
        public string Stadium {get; set;}
        public int GoalsTeam1 { get; set; }
        public int GoalsTeam2 { get; set; }
    }
}