using Avalonia.Media;
using Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using CursWorkAvalonia.Models;
using System.Collections.Specialized;


namespace CursWorkAvalonia.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        private Request _request;
        public Request SelectedRequest
        {
            get => _request;
            set => this.RaiseAndSetIfChanged(ref _request,value);
        }    

        private ObservableCollection<Player> _players;
        private ObservableCollection<PlayersResult> _playersResult;
        private ObservableCollection<Team> _teams;
        private ObservableCollection<TeamsLineUp> _teamsLineUps;
        private ObservableCollection<TeamsResult> _teamsResults;
        private ObservableCollection<TopManager> _topManagers;
        private ObservableCollection<Tournament> _tournaments;
        private ObservableCollection<TournamentsTeam> _tournamentsTeams;
        public ObservableCollection<Player> Players { 
            get => _players; 
            set => this.RaiseAndSetIfChanged(ref _players,value); 
        }
        public ObservableCollection<PlayersResult> PlayersResults
        {
            get => _playersResult;
            set => this.RaiseAndSetIfChanged(ref _playersResult, value);
        }
        public ObservableCollection<Team> Teams
        {
            get =>_teams;
            set => this.RaiseAndSetIfChanged(ref _teams, value);
        }
        public ObservableCollection<TeamsLineUp> TeamsLineUps
        {
            get => _teamsLineUps;
            set => this.RaiseAndSetIfChanged(ref _teamsLineUps, value);
        }
        public ObservableCollection<TeamsResult> TeamsResults
        {
            get => _teamsResults;
            set => this.RaiseAndSetIfChanged(ref _teamsResults, value);
        }
        public ObservableCollection<TopManager> TopManagers
        {
            get => _topManagers;
            set => this.RaiseAndSetIfChanged(ref _topManagers, value);
        }
        public ObservableCollection<Tournament> Tournaments
        {
            get => _tournaments;
            set => this.RaiseAndSetIfChanged(ref _tournaments, value);
        }
        public ObservableCollection<TournamentsTeam> TournamentsTeams
        {
            get => _tournamentsTeams;
            set => this.RaiseAndSetIfChanged(ref _tournamentsTeams, value);
        }

        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set => this.RaiseAndSetIfChanged(ref _requests, value);
        }
        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }
        
        public MainWindowViewModel()
        {
            using(var db = new mlbContext())
            {
                this.Players = new ObservableCollection<Player>(db.Players);
                this.PlayersResults = new ObservableCollection<PlayersResult>(db.PlayersResults);
                this.Teams = new ObservableCollection<Team>(db.Teams);
                this.TeamsLineUps = new ObservableCollection<TeamsLineUp>(db.TeamsLineUps);
                this.TeamsResults = new ObservableCollection<TeamsResult>(db.TeamsResults);
                this.TopManagers = new ObservableCollection<TopManager>(db.TopManagers);
                this.Tournaments = new ObservableCollection<Tournament>(db.Tournaments);
                this.TournamentsTeams = new ObservableCollection<TournamentsTeam>(db.TournamentsTeams);

            }
            Content = new DataBaseViewModel();
            Requests = new ObservableCollection<Request>()
            {
                new Request("1"),
                new Request("2")
            };

          
        }
        public void CreateRequest()
        {
            Requests.Add(new Request("New request"));
        }
        public void DeleteRequest(Request e)
        {
            Requests.Remove(e);
        }

        public void DeleteTeam(Team e) => Teams.Remove(e);
        public void DeletePlayer(Player e) => Players.Remove(e);
        public void DeletePlayersResult(PlayersResult e) => PlayersResults.Remove(e);
        public void DeleteTeamsLineUp(TeamsLineUp e) => TeamsLineUps.Remove(e);
        public void DeleteTeamsResults(TeamsResult e) => TeamsResults.Remove(e);
        public void DeleteTopManager(TopManager e) => TopManagers.Remove(e);
        public void DeleteTournament(Tournament e) => Tournaments.Remove(e);
        public void DeleteTournamentsTeam(TournamentsTeam e) => TournamentsTeams.Remove(e);

        public void CreateTeam() => Teams.Add(new Team() {Name = "new" });
        public void CreatePlayer() => Players.Add(new Player() { Name = "new" });
        public void CreatePlayersResult() => PlayersResults.Add(new PlayersResult { PlayerId = 1, Result = 0 });
        public void CreateTeamsLineUp() => TeamsLineUps.Add(new TeamsLineUp() { TeamId = 1, PlayerId = 1 });
        public void CreateTeamResult() => TeamsResults.Add(new TeamsResult() {  Result = 0, TeamId = 1, TournamentId = 1});
        public void CreateTopManager() => TopManagers.Add(new TopManager() { Name = "new" });
        public void CreateTournament() => Tournaments.Add(new Tournament() { Name = "new", Time = "01.01.1997" });
        public void CreateTournamentsTeam() => TournamentsTeams.Add(new TournamentsTeam() { TeamId = 1, TournamentId = 1});

        public void SQLRequestOpen() => Content = new SQLRequestViewModel();
        public void SQLRequestRun()
        {
            
            using(var db = new mlbContext())
            {
               //Сделать реализацию запросов, через свитч команды(SELECT JOIN и т.д.), в кейсах сам запрос, результат записывать в список запросов
               // Тип списка запросов? Отдельный класс?
            }
            Content = new DataBaseViewModel();
        }
    }
}
