import { Injectable } from '@nestjs/common';

@Injectable()
export class ClienteService {
  private clientes: any[] = [];

  create(cliente: any) {
    this.clientes.push(cliente);
  }

  findAll() {
    return this.clientes;
  }
}