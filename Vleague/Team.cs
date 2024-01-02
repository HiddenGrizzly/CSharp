using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vleague
{
    public class Team
    {
        public string TeamCode { get; set; }
        public string TeamName { get; set; }
        public string Coach { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }

        public Team()
        {
            MatchesPlayed = 0;
            Wins = 0;
            Draws = 0;
            Losses = 0;
        }
        public void AddNewTeam(List<Team> teams)
        {
            Console.WriteLine("=====Thêm mới một đội bóng=======");
            Console.Write("Nhập mã đội: ");
            string teamCode = Console.ReadLine();

            Console.Write("Nhập tên đội: ");
            string teamName = Console.ReadLine();

            Console.Write("Nhập tên huấn luyện viên: ");
            string coach = Console.ReadLine();

            Team newTeam = new Team { TeamCode = teamCode, TeamName = teamName, Coach = coach };
            teams.Add(newTeam);

            Console.WriteLine("Thêm đội thành công!");
        }
        public void UpdateTeamInformation(List<Team> teams)
        {
            Console.Write("Nhập mã đội: ");
            string teamCode = Console.ReadLine();

            Team teamToUpdate = teams.Find(t => t.TeamCode == teamCode);

            if (teamToUpdate != null)
            {
                Console.Write("Sửa tên đội: ");
                string teamName = Console.ReadLine();

                Console.Write("Sửa tên huấn luyện viên: ");
                string coach = Console.ReadLine();

                bool flag = true;
                while (flag) 
                {
                    Console.Write("Bạn muốn cập nhật thông tin?(Y/N)");
                    string choose = Console.ReadLine();
                    if (choose == "Y") 
                    {
                        teamToUpdate.TeamName = teamName;
                        teamToUpdate.Coach = coach;
                        Console.WriteLine("Team information updated successfully!");
                        flag = false;
                    }
                    else if (choose == "N") 
                    {
                        Console.WriteLine("Ngừng cập nhật đội!");
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
                Console.WriteLine("Không tìm được đội.");
            }
        }
        public void ViewTeams(List<Team> teams)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("| STT | Mã đội | Tên đội           | Huấn luyện viên |");
            Console.WriteLine("=================================");

            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine($"| {i + 1,-4} | {teams[i].TeamCode}   | {teams[i].TeamName,-17} | {teams[i].Coach,-15} |");
            }

            Console.WriteLine("=================================");
        }
        public void ViewRanking(List<Team> teams)
        {
            Console.WriteLine("=================================================================");
            Console.WriteLine("| Mã đội | Tên đội           | Trận | Thắng | Hòa | Thua | Điểm |");
            Console.WriteLine("=================================================================");

            foreach (var team in teams)
            {
                Console.WriteLine($"| {team.TeamCode}   | {team.TeamName,-17} | {team.MatchesPlayed,-4} | {team.Wins,-5} | {team.Draws,-4} | {team.Losses,-5} | {CalculatePoints(team),-5} |");
            }

            Console.WriteLine("=================================================================");
        }

        private int CalculatePoints(Team team)
        {
            return team.Wins * 3 + team.Draws;
        }
        public void ViewTeamsOrderedByName(List<Team> teams)
        {
            var orderedTeams = teams.OrderBy(t => t.TeamName).ToList();

            Console.WriteLine("================================================");
            Console.WriteLine("| Mã đội | Tên đội           | Huấn luyện viên |");
            Console.WriteLine("================================================");

            for (int i = 0; i < orderedTeams.Count; i++)
            {
                Console.WriteLine($"| {orderedTeams[i].TeamCode,-6} | {orderedTeams[i].TeamName,-17} | {orderedTeams[i].Coach,-15} |");
            }

            Console.WriteLine("================================================");
        }
        public void ViewTeamsOrderedByCode(List<Team> teams)
        {
            var orderedTeams = teams.OrderBy(t => t.TeamCode).ToList();

            Console.WriteLine("================================================");
            Console.WriteLine("| Mã đội | Tên đội           | Huấn luyện viên |");
            Console.WriteLine("================================================");

            for (int i = 0; i < orderedTeams.Count; i++)
            {
                Console.WriteLine($"| {orderedTeams[i].TeamCode,-6} | {orderedTeams[i].TeamName,-17} | {orderedTeams[i].Coach,-15} |");
            }

            Console.WriteLine("================================================");
        }
    }
}