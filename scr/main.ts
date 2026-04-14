import { NestFactory } from '@nestjs/core';
import { AppModules } from './app.modules';
import * as path from 'path';

async function bootstrap() {
  const app = await NestFactory.create(AppModules);

  app.setBaseViewsDir(path.join(__dirname, '..', 'views'));
  app.setViewEngine('ejs');

  await app.listen(3000);
}
bootstrap();