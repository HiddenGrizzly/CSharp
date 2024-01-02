using System;
using System.Collections.Generic;

namespace Vleague
{
    class Program
    {
        static void Main()
        {
            List<Team> teams = new List<Team>();
            List<Match> matches = new List<Match>();

            Team teamManager = new Team();
            Match matchManager = new Match();

            int choice;
            do
            {
                DisplayMainMenu();
                Console.Write("#Chọn: ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ManageTeamsSubMenu(teamManager, teams);
                            break;
                        case 2:
                            ManageScheduleSubMenu(matchManager, teams, matches);
                            break;
                        case 3:
                            ManageMatchResultSubMenu(matchManager, matches);
                            break;
                        case 4:
                            DisplayRankingSubMenu(teamManager, teams);
                            break;
                        case 0:
                            Console.WriteLine("Chúc các đội giải V-League thành công!");
                            break;
                        default:
                            Console.WriteLine("Chọn sai. Hãy chọn lại.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Chọn sai. Hãy chọn lại.");
                }

            } while (choice != 0);
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("--Chào mừng đến với V-League 2023-----");
            Console.WriteLine("=================================");
            Console.WriteLine("−\t1. Quản lý danh sách đội bóng.");
            Console.WriteLine("−\t2. Quản lý lịch thi đấu.");
            Console.WriteLine("−\t3. Quản lý kết quả thi đấu.");
            Console.WriteLine("−\t4. Thống kê.");
            Console.WriteLine("−\t0. Thoát.");
        }

        static void ManageTeamsSubMenu(Team teamManager, List<Team> teams)
        {
            int teamChoice;
            do
            {
                DisplayTeamsSubMenu();
                Console.Write("#Chọn: ");
                if (int.TryParse(Console.ReadLine(), out teamChoice))
                {
                    switch (teamChoice)
                    {
                        case 1:
                            teamManager.ViewTeams(teams);
                            break;
                        case 2:
                            teamManager.UpdateTeamInformation(teams);
                            break;
                        case 3:
                            teamManager.AddNewTeam(teams);
                            break;
                        case 4:
                            teamManager.ViewTeamsOrderedByCode(teams);
                            break;
                        case 5:
                            teamManager.ViewTeamsOrderedByName(teams);
                            break;
                        case 0:
                            Console.WriteLine("Trở về menu chính.");
                            break;
                        default:
                            Console.WriteLine("Chọn sai. Hãy chọn lại.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Chọn sai. Hãy chọn lại.");
                }

            } while (teamChoice != 0);
        }

        static void DisplayTeamsSubMenu()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("−\t1. Xem danh sách đội bóng");
            Console.WriteLine("−\t2. Cập nhật danh sách đội bóng");
            Console.WriteLine("−\t3. Thêm mới một đội bóng");
            Console.WriteLine("−\t4. Xem danh sách theo thứ tự mã đội");
            Console.WriteLine("−\t5. Xem danh sách đội bóng theo tên đội");
            Console.WriteLine("−\t0. Trở về menu chính.");
        }

        static void ManageScheduleSubMenu(Match matchManager, List<Team> teams, List<Match> matches)
        {
            int scheduleChoice;
            do
            {
                DisplayScheduleSubMenu();
                Console.Write("#Chọn: ");
                if (int.TryParse(Console.ReadLine(), out scheduleChoice))
                {
                    switch (scheduleChoice)
                    {
                        case 1:
                            matchManager.ViewSchedule(matches);
                            break;
                        case 2:
                            matchManager.UpdateMatchInformation(matches);
                            break;
                        case 3:
                            matchManager.CreateNewMatch(matches, teams);
                            break;
                        case 0:
                            Console.WriteLine("Trở về menu chính.");
                            break;
                        default:
                            Console.WriteLine("Chọn sai. Hãy chọn lại.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Chọn sai. Hãy chọn lại.");
                }

            } while (scheduleChoice != 0);
        }

        static void DisplayScheduleSubMenu()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("−\t1. Xem lịch thi đấu");
            Console.WriteLine("−\t2. Cập nhật cập nhật lịch thi đấu");
            Console.WriteLine("−\t3. Tạo lịch thi đấu");
            Console.WriteLine("−\t0. Trở về menu chính.");
        }

        static void ManageMatchResultSubMenu(Match matchManager, List<Match> matches)
        {
            int resultChoice;
            do
            {
                DisplayResultSubMenu();
                Console.Write("#Chọn: ");
                if (int.TryParse(Console.ReadLine(), out resultChoice))
                {
                    switch (resultChoice)
                    {
                        case 1:
                            matchManager.ViewMatchResult(matches);
                            break;
                        case 2:
                            matchManager.UpdateMatchResult(matches);
                            break;
                        case 0:
                            Console.WriteLine("Trở về menu chính.");
                            break;
                        default:
                            Console.WriteLine("Chọn sai. Hãy chọn lại.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Chọn sai. Hãy chọn lại.");
                }

            } while (resultChoice != 0);
        }

        static void DisplayResultSubMenu()
        {
            Console.WriteLine("=========Kết quả thi đấu=========");
            Console.WriteLine("−\t1. Xem kết quả thi đấu");
            Console.WriteLine("−\t2. Cập nhật kết quả thi đấu");
            Console.WriteLine("−\t0. Trở về menu chính.");
        }

        static void DisplayRankingSubMenu(Team teamManager, List<Team> teams)
        {
            teamManager.ViewRanking(teams);
        }
    }
}
