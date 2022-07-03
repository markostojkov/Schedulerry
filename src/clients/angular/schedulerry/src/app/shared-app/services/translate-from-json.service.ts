import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LOCATION_INITIALIZED } from '@angular/common';

import { TranslateLoader, TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs';

import { environment } from '@env/environment';

export function translateConfiguration(translateService: TranslateService, injector: Injector): () => Promise<boolean> {
  return () =>
    new Promise<boolean>((resolve) => {
      const locationInitialized = injector.get(LOCATION_INITIALIZED, Promise.resolve(null));
      locationInitialized.then(() => {
        const defaultLang = environment.language;
        translateService.setDefaultLang(defaultLang);
        translateService.use(defaultLang).subscribe(
          () => {},
          () => {},
          () => {
            resolve(true);
          }
        );
      });
    });
}
@Injectable()
export class TranslateFromJsonService implements TranslateLoader {
  constructor(private http: HttpClient, private translateService: TranslateService) {}

  getTranslation(lang: string): Observable<object> {
    let url = '';

    switch (lang) {
      case 'en':
        url = environment.translations.en;
        break;
      default:
        break;
    }

    return this.http.get(url);
  }

  public instant(key?: string): string | undefined {
    if (key) {
      return this.translateService.instant(key);
    }
    return undefined;
  }
}
