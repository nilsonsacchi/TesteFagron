import { NgModule } from '@angular/core';
import { ClienteService } from '../servicos/clientservice.service'
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { BuscarClienteComponente } from './components/cliente/buscacliente/Buscarcliente.componente'
import { createcliente } from './components/cliente/addcliente/Addcliente.componente'
@NgModule({
	declarations: [
		AppComponent,
		NavMenuComponent,
		HomeComponent,
		BuscarClienteComponente,
		createcliente,
	],
	imports: [
		CommonModule,
		HttpModule,
		FormsModule,
		ReactiveFormsModule,
		RouterModule.forRoot([
			{ path: '', redirectTo: 'home', pathMatch: 'full' },
			{ path: 'home', component: HomeComponent },
			{ path: 'busca-cliente', component: BuscarClienteComponente },
			{ path: 'register-cliente', component: createcliente },
			{ path: 'cliente/edit/:id', component: createcliente },
			{ path: '**', redirectTo: 'home' }
		])
	],
	providers: [ClienteService]
})
export class AppModuleShared {
}