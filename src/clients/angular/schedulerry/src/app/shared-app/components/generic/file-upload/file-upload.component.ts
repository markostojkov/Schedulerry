import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { switchMap } from 'rxjs/operators';

import { BaseApiService } from 'src/app/shared-app/services/base-api.service';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent implements OnInit {
  @Input() urlToUploadImageTo!: Observable<string>;
  @Output() imageUploadedTo = new EventEmitter<string>();

  private imageUrl = '';

  constructor(private api: BaseApiService) {}

  ngOnInit(): void {}

  onChange(event: Event): void {
    const target = event.target as HTMLInputElement;

    if (target.files && target.files[0]) {
      const file = target.files[0];

      this.urlToUploadImageTo
        .pipe(
          switchMap((urlToUploadTo) => {
            this.imageUrl = `http://dolvqfvzzy75k.cloudfront.net${new URL(urlToUploadTo.split('?')[0]).pathname}`;
            return this.api.putFile(urlToUploadTo, file);
          })
        )
        .subscribe(() => {
          this.imageUploadedTo.emit(this.imageUrl);
        });
    }
  }
}
