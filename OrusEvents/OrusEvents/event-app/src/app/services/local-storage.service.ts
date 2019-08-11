import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {

  constructor() { }
  set(key, value) {
    localStorage[key] = value;
    return this;
  }

  get(key, defatulValue = null) {
    return localStorage[key] || defatulValue;
  }

  setObject(key, value: object) {
    localStorage[key] = JSON.stringify(value);
    return this;
  }

  getObject(key) {
    return JSON.parse(localStorage[key] || null);
  }

  remove(key) {
    localStorage.removeItem(key);
  }
}
