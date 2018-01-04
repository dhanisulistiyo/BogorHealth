import { RegisterPage } from './../pages/register/register';
import { AntrianPage } from './../pages/antrian/antrian';
import { JadwalLayananPage } from './../pages/jadwal-layanan/jadwal-layanan';
import { DetailChatPage } from './../pages/detail-chat/detail-chat';
import { UserProfilPage } from './../pages/user-profil/user-profil';
import { DetailHospitalPage } from './../pages/detail-hospital/detail-hospital';
import { DetailDokterPage } from './../pages/detail-dokter/detail-dokter';
import { TabsHomePage } from './../pages/tabs-home/tabs-home';
import { ListServicesPage } from './../pages/list-services/list-services';
import { ListDokterPage } from './../pages/list-dokter/list-dokter';
import { LoginPage } from './../pages/login/login';
import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { AuthServiceProvider } from '../providers/auth-service';
import { ChatHistoryPage } from '../pages/chat-history/chat-history';
import { ListHospitalPage } from '../pages/list-hospital/list-hospital';
import { ConfigProvider } from '../providers/config';
import { HttpModule } from '@angular/http';
import { HospitalServiceProvider } from '../providers/hospital-service';
import { LayananServiceProvider } from '../providers/layanan-service';
import { DokterServiceProvider } from '../providers/dokter-service';
import { HistoryAntrianPage } from '../pages/history-antrian/history-antrian';


@NgModule({
  declarations: [
    MyApp,
    LoginPage,
    HomePage,
    ChatHistoryPage,
    ListDokterPage,
    ListHospitalPage,
    ListServicesPage,
    TabsHomePage,
    DetailDokterPage,
    DetailHospitalPage,
    UserProfilPage,
    DetailChatPage,
    JadwalLayananPage,
    AntrianPage,
    RegisterPage,
    HistoryAntrianPage
  ],
  imports: [
    BrowserModule,
    HttpModule,
    IonicModule.forRoot(MyApp, {
      platforms: {
        ios: {
          // These options are available in ionic-angular@2.0.0-beta.2 and up.
          scrollAssist: false,    // Valid options appear to be [true, false]
          autoFocusAssist: false  // Valid options appear to be ['instant', 'delay', false]
        },
        md: {
          // These options are available in ionic-angular@2.0.0-beta.2 and up.
          scrollAssist: false,    // Valid options appear to be [true, false]
          autoFocusAssist: false  // Valid options appear to be ['instant', 'delay', false]
        }
      },
      mode: 'md',
      tabsHideOnSubPages: "true",
      scrollAssist: false
    }),
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    LoginPage,
    HomePage,
    ChatHistoryPage,
    ListDokterPage,
    ListHospitalPage,
    ListServicesPage,
    TabsHomePage,
    DetailDokterPage,
    DetailHospitalPage,
    UserProfilPage,
    DetailChatPage,
    JadwalLayananPage,
    AntrianPage,
    RegisterPage,
    HistoryAntrianPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    AuthServiceProvider,
    ConfigProvider,
    HospitalServiceProvider,
    LayananServiceProvider,
    DokterServiceProvider
  ]
})
export class AppModule {}
