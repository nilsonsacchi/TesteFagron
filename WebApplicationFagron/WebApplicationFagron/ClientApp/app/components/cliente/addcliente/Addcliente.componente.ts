import { Component, OnInit } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { NgForm, FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { BuscarClienteComponente } from '../buscacliente/Buscarcliente.componente';
import { ClienteService } from '../../../../servicos/clientservice.service';
@Component({
	selector: 'createcliente',
	templateUrl: './Addcliente.componente.html'
})
export class createcliente implements OnInit {
	clienteForm: FormGroup;
	title: string = "Cadastro";
	id: number;
	errorMessage: any;
	constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
		private _clienteService: ClienteService, private _router: Router) {
		if (this._avRoute.snapshot.params["id"]) {
			this.id = this._avRoute.snapshot.params["id"];
		}
		this.clienteForm = this._fb.group({
			id: 0,
			name: ['', [Validators.required]],
			gender: ['', [Validators.required]],
			department: ['', [Validators.required]],
			city: ['', [Validators.required]]
		})
	}
	ngOnInit() {
		if (this.id > 0) {
			this.title = "Editar";
			this._clienteService.getCliente(this.id)
				.subscribe(resp => this.clienteForm.setValue(resp)
				, error => this.errorMessage = error);
		}
	}
	save() {
		if (!this.clienteForm.valid) {
			return;
		}
		if (this.title == "Cadastro") {
			this._clienteService.saveCliente(this.clienteForm.value)
				.subscribe((data) => {
					this._router.navigate(['/busca-cliente']);
				}, error => this.errorMessage = error)
		}
		else if (this.title == "Editar") {
			this._clienteService.updateCliente(this.clienteForm.value)
				.subscribe((data) => {
					this._router.navigate(['/busca-cliente']);
				}, error => this.errorMessage = error)
		}
	}
	cancel() {
		this._router.navigate(['/busca-cliente']);
	}
	get nome() { return this.clienteForm.get('nome'); }
	get sobrenome() { return this.clienteForm.get('sobrenome'); }
	get cpf() { return this.clienteForm.get('cpf'); }
	get dtnasc() { return this.clienteForm.get('dt_nasc'); }
	get idade() { return this.clienteForm.get('idade'); }
	get profissao() { return this.clienteForm.get('profissao'); }
}