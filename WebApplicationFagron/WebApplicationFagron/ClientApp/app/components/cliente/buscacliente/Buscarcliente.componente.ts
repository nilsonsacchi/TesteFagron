import { Component, Inject } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { ClienteService } from '../../../../servicos/clientservice.service'
@Component({
	selector: 'Buscarcliente',
	templateUrl: './Buscarcliente.componente.html'
})
export class BuscarClienteComponente {
	public cliList: ClienteData[];
	constructor(public http: Http, private _router: Router, private _clienteService: ClienteService) {
		this.getCliente();
	}
	getCliente() {
		this._clienteService.getAllCliente().subscribe(
			data => this.cliList = data
		)
	}
	delete(clienteID) {
		var ans = confirm("Deseja deletar esse registro: " + clienteID);
		if (ans) {
			this._clienteService.deleteCliente(clienteID).subscribe((data) => {
				this.getCliente();
			}, error => console.error(error))
		}
	}
}
interface ClienteData {
	id: number;
	nome: string;
	sobrenome: string;
	cpf: string;
	dt_nasc: string;
	idade: number;
	profissao: number;
}