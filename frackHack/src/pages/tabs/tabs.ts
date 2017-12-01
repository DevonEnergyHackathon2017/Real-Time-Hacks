
import { Component } from '@angular/core';

import { SettingsPage } from '../settings/settings';
import { LeaderboardPage } from '../leaderboard/leaderboard';
import { HomePage } from '../home/home';
import { LivePage } from '../live/live';

@Component({
  templateUrl: 'tabs.html'
})
export class TabsPage {

  tab1Root = HomePage;
  tab2Root = LivePage;
  tab3Root = LeaderboardPage;
  tab4Root = SettingsPage;
  constructor() {

  }
}
