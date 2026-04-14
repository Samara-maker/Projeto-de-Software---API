import { Injectable } from '@nestjs/common';

@Injectable()
export class ClienteService {
  private clientes = [];

  create(cliente) {
    this.clientes.push(cliente);
  }

  findAll() {
    return this.clientes;
  }
}