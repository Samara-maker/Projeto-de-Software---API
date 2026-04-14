import { Controller, Get, Post, Body, Render } from '@nestjs/common';

@Controller('clientes')
export class ClienteController {
  private clientes = [];

  @Get()
  @Render('cliente/index')
  listar() {
    return { clientes: this.clientes };
  }

  @Get('/novo')
  @Render('cliente/novo')
  novo() {
    return {};
  }

  @Post()
  criar(@Body() body) {
    this.clientes.push(body);
    return { message: 'ok' };
  }
}