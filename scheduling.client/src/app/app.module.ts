import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { authInterceptor } from './core/interceptors/auth.interceptor';
import { SharedModule } from './shared/shared.module';
import { AppRoutingModule } from './app-routing.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    AppRoutingModule,
    SharedModule,
  ],
  providers: [
    provideHttpClient(
      withInterceptors([authInterceptor])
    )],
  bootstrap: [AppComponent]
})
export class AppModule { }
