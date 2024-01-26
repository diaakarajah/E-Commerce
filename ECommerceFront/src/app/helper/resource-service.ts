import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ResourceModel } from './resource-model';



export abstract class ResourceService<T extends ResourceModel<T>> {
  baseUrl = 'https://localhost:5001/api/';

  constructor(
    private httpClient: HttpClient,
    private tConstructor: { new(m: Partial<T>, ...args: unknown[]): T },
    protected apiUrl: string
  ) { }

  public create(resource: Partial<T> & { toJson: () => T }): Observable<T> {
    return this.httpClient
      .post<T>(`${this.baseUrl}${this.apiUrl}`, resource.toJson())
      .pipe(map((result) => new this.tConstructor(result)));
  }

  public get(filter: any): Observable<T[]> {
    return this.httpClient
      .get<T[]>(`${this.baseUrl}${this.apiUrl}`)
      .pipe(map((result) => result.map((i) => new this.tConstructor(i))));
  }

  public getById(id: number): Observable<T> {
    return this.httpClient
      .get<T>(`${this.baseUrl}${this.apiUrl}/${id}`)
      .pipe(map((result) => new this.tConstructor(result)));
  }

  public update(resource: Partial<T> & { toJson: () => T }): Observable<T> {
    return this.httpClient
      .put<T>(`${this.baseUrl}${this.apiUrl}${resource.id}`, resource.toJson())
      .pipe(map((result) => new this.tConstructor(result)));
  }

  public delete(id: number): Observable<void> {
    return this.httpClient.delete<void>(`${this.baseUrl}${this.apiUrl}/${id}`);
  }
  public UploadFile(Form: any): Observable<void> {
    return this.httpClient.post<any>(`${this.baseUrl}${this.apiUrl}/Upload`, Form);
  }
}
