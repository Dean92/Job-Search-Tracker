import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterComponent } from './register/register.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { JobListComponent } from './job-list/job-list.component';
import { UserHomeComponent } from './user-home/user-home.component';
import { AuthGuard } from './_guards/auth.guard';
import { SharedModule } from './_modules/shared.module';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { ModalModule } from 'ngx-bootstrap/modal';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    PageNotFoundComponent,
    JobListComponent,
    UserHomeComponent,
    TestErrorComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,

    HttpClientModule,
    FormsModule,
    SharedModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
          { path: 'job-list', component: JobListComponent },
          {
            path: 'user-home',
            component: UserHomeComponent,
          },
        ],
      },

      { path: 'home', component: HomeComponent },
      { path: 'not-found', component: PageNotFoundComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'test-error', component: TestErrorComponent },
      { path: '**', component: PageNotFoundComponent, pathMatch: 'full' },
    ]),
    ModalModule.forRoot(),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
