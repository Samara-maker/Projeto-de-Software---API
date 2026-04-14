import { Controller, Get, Post, Body, Render } from '@nestjs/common';
import { ClienteService } from './cliente.service';

@Controller('clientes')
export class ClienteController {
  constructor(private readonly clienteService: ClienteService) {}

  @Get()
  @Render('cliente/index')
  listar() {
    return { clientes: this.clienteService.findAll() };
  }

  @Get('/novo')
  @Render('cliente/novo')
  novo() {
    return {};
  }

  @Post()
  criar(@Body() body: any) {
    this.clienteService.create(body);
    return { message: 'ok' };
  }
}
