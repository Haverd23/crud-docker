import { Component, OnInit } from '@angular/core';
import { PessoaServiceService } from './pessoa-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  pessoas: any[] = [];

  pessoaEditada: any = null;  
  pessoaAtual: any = { nome: '', idade: null, cpf: '' };  

  constructor(private pessoaService: PessoaServiceService) {}

  ngOnInit(): void {
    this.carregarPessoas();  
  }

  carregarPessoas(): void {
    this.pessoaService.getPessoas().subscribe({
      next: (data) => {
        console.log('Pessoas carregadas:', data);
        this.pessoas = data;
      },
      error: (err) => {
        console.error('Erro ao buscar pessoas', err);
      }
    });
  }

  criarPessoa(): void {
    if (this.pessoaAtual.nome && this.pessoaAtual.idade && this.pessoaAtual.cpf) {
      this.pessoaService.createPessoa(this.pessoaAtual).subscribe({
        next: (data) => {
          console.log('Pessoa criada com sucesso!', data);
          this.pessoas.push(data); 
          this.pessoaAtual = { nome: '', idade: null, cpf: '' };  
        },
        error: (err) => {
          console.error('Erro ao criar pessoa', err);
        }
      });
    } else {
      console.error('Preencha todos os campos!');
    }
  }

  editarPessoa(pessoa: any): void {
    this.pessoaEditada = { ...pessoa }; 
    this.pessoaAtual = { ...pessoa };  
  }
  limpar(){
    this.pessoaAtual = { nome: '', idade: null, cpf: '' }; 
    this.pessoaEditada = null; 
  }

  atualizarPessoa(): void {
    if (this.pessoaAtual) {
      this.pessoaService.updatePessoa(this.pessoaAtual).subscribe({
        next: (data) => {
          console.log('Pessoa atualizada com sucesso!', data);
         
          const index = this.pessoas.findIndex(p => p.id === data.id);
          if (index !== -1) {
            this.pessoas[index] = data;
          }
          this.pessoaAtual = { nome: '', idade: null, cpf: '' }; 
          this.pessoaEditada = null;  
        },
        error: (err) => {
          console.error('Erro ao atualizar pessoa', err);
        }
      });
    }
  }

  deletarPessoa(id: number): void {
    if (confirm('Tem certeza que deseja excluir esta pessoa?')) {
      this.pessoaService.deletePessoa(id).subscribe({
        next: (data) => {
          console.log('Pessoa deletada com sucesso!', data);
          this.pessoas = this.pessoas.filter(pessoa => pessoa.id !== id);
        },
        error: (err) => {
          console.error('Erro ao deletar pessoa', err);
        }
      });
    }
  }
}
