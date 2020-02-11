import { Observable, Subscription, of, fromEvent, from, empty, merge, timer, throwError, pipe } from 'rxjs';
import {
    map,
    mapTo,
    switchMap,
    tap,
    mergeMap,
    takeUntil,
    filter,
    finalize,
    retryWhen,
    catchError,
    shareReplay,
    flatMap,
    delay,
} from 'rxjs/operators';
import { genericRetryStrategy } from '../utils/rx/genericRetryStrategy';

type PromiseResult = void | ((any: any) => void);

export class ImageFactoryService {
    collectionID = [
        9421013,
        9473642,
        8929862,
        2297394,
        6873544,
        1381234,
        8967691,
        8078319,
        4621081,
        9349656,
        8357547,
        6873544,
        4458858,
    ];

    public tryGetImageAsync(imageId: number, width: number = 180, height: number = 140): Observable<string> {
        const collectionNumber = this.collectionID[0];

        return from(
            new Promise<string>(resolve => {
                this.tryGetImageFromLocalStorage(imageId)
                    .pipe(
                        switchMap(imageBase64Data =>
                            // imageBase64Data === null
                            true
                                ? this.fetchAnImageSrc(collectionNumber, width, height).pipe(
                                      switchMap(imageSrc => this.getBase64String(imageSrc, width, height)),
                                  )
                                : of(imageBase64Data),
                        ),
                        map(base64 => {
                            this.setImageToLocalStorage(imageId, base64!);
                            return this.interpolateImageStringWith(base64!, width, height);
                        }),
                    )
                    .subscribe(
                        imageTag => resolve(imageTag),
                        err => console.log('HTTP Error', err),
                        () => console.log('HTTP request completed.'),
                    );
            }),
        );

        // retryWhen(genericRetryStrategy()),
        //                         catchError(error => {
        //                             return of(`Bad Promise: ${error}`);
        //                         }),

        // retryWhen(genericRetryStrategy()),
        // catchError(error => {
        //     return of(`Bad Promise: ${error}`);
        // }),

        // let base64ImageData = this.tryGetImageFromLocalStorage(imageId);

        // if (base64ImageData !== null) {
        //     return this.interpolateImageStringWith(base64ImageData, width, height);
        // }

        // this.fetchAnImageSrc(collectionNumber, width, height)
        //     .pipe(
        //         retryWhen(genericRetryStrategy()),
        //         catchError(error => of(error)),
        //     )
        //     .pipe()
        //     .subscribe(console.log);

        // var imageSrc = await this.fetchAnImageSrc(collectionNumber, width, height);

        // base64ImageData = await this.getBase64String(imageSrc, width, height);
        // localStorage.setItem(`image:${imageId}`, base64ImageData);

        // return this.interpolateImageStringWith(base64ImageData, width, height);
    }

    private onload2promise<T extends { onload: any; onerror: any }>(obj: T): Promise<T> {
        return new Promise((resolve, reject) => {
            obj.onload = () => resolve(obj);
            obj.onerror = reject;
        });
    }

    private fetchAnImageSrc(collectionID: number, width: number, height: number): Observable<string> {
        return from(
            new Promise<string>((resolve, reject) => {
                return fetch(`https://source.unsplash.com/collection/${collectionID}/${width}x${height}`)
                    .then(response => {
                        console.log('FETCH', response.url);
                        resolve(response.url);
                    })
                    .catch(() => reject());
            }),
        );
    }

    private getBase64String = (imgSrc: string, width: number, height: number): Observable<string> => {
        return from(
            new Promise<string>(async (resolve, reject) => {
                var imgElement = document.createElement('img');
                imgElement.crossOrigin = '*';
                imgElement.src = imgSrc.replace('fm=jpg', 'fm=png');

                this.onload2promise(imgElement).then(() => {
                    try {
                        var canvas = document.createElement('canvas');
                        var ctx = canvas.getContext('2d');
                        canvas.width = width;
                        canvas.height = height;

                        ctx!.drawImage(imgElement, 0, 0);
                        var dataURL = canvas.toDataURL('image/png');
                        resolve(dataURL);
                    } catch (err) {
                        console.log('ERROR');
                        reject(err);
                    }
                });
            }),
        );
    };

    private interpolateImageStringWith(base64: string, width: number, height: number): string {
        return `<img class="gallery-image" src="${base64}" width="${width}" height="${height}" alt="gallery image"/>`;
    }

    private tryGetImageFromLocalStorage = (id: number) => of(localStorage.getItem(`image:${id}`));
    private setImageToLocalStorage = (id: number, base64: string) => localStorage.setItem(`image:${id}`, base64);
}
