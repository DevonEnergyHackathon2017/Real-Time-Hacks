import { NgModule, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { MyApp } from './app.component';

import { HomePage } from '../pages/home/home';
import { LeaderboardPage } from '../pages/leaderboard/leaderboard';
import { SettingsPage } from '../pages/settings/settings';
import { TabsPage } from '../pages/tabs/tabs';
import { LivePage } from '../pages/live/live';
import { InfoModalPage } from '../pages/infomodal/infomodal';
import { HttpClientModule } from '@angular/common/http';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    LeaderboardPage,
    SettingsPage,
    TabsPage,
    LivePage,
    InfoModalPage,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    IonicModule.forRoot(MyApp)
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    LeaderboardPage,
    SettingsPage,
    TabsPage,
    LivePage,
    InfoModalPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler}
  ]
})
export class AppModule {}
