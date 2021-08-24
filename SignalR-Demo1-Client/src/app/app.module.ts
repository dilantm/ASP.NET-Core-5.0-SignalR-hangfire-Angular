import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './home/home.component';
import { DataService } from './_services/data.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FakeBackendInterceptor, FakeBackendProvider } from './_helper/fake-backend-intercepter';
import { FakeRequestChangeProvider } from './_helper/fake-requestchange-intercepter';
import { MessageComponent } from './message/message.component';
import { SendmessageComponent } from './sendmessage/sendmessage.component';
import { FakeErrorInterceptor } from './_helper/ErrorInterceptor';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [
    AppComponent,
   
    HomeComponent,
    
    // MessageComponent,
    // SendmessageComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule,
    HttpClientModule
  ],
  providers: [DataService],//, FakeBackendProvider],// [DataService, FakeErrorInterceptor, FakeBackendProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }
