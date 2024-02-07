import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'enum',
  standalone: true
})
export class EnumPipe implements PipeTransform {

  transform(data: Object) {
    const keys = Object.keys(data);
    return keys.slice(keys.length / 2);
  }

}
