import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'truncate'
})
export class TruncatePipe implements PipeTransform {
  transform(value: string | null | undefined, limit = 25): string | null {
    if (value) {
      if (value.length <= limit) {
        return value;
      }

      return `${value.substr(0, limit)}...`;
    }

    return null;
  }
}
