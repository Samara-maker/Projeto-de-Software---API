import { Module } from '@nestjs/common';
import { ClienteModule } from './modules/cliente/cliente.module';

@Module({
  imports: [ClienteModule],
})
export class AppModule {}