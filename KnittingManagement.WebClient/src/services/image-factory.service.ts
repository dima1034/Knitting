export class ImageFactoryService {
    // numImagesAvailable = 988; //how many photos are total in the collection
    // numItemsToGenerate = 20; //how many photos you want to display

    // imageWidth = 480; //image width in pixels
    // imageHeight = 480; //image height in pixels
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
    ]; //Beach & Coastal, the collection ID from the original url

    // galleryContainer = document.querySelector('.gallery-container');

    //    API =
    //        'https://api.unsplash.com/search/photos/?page=1&query=wallpaper gradient&client_id=e56723ba59a05dbf2e400475b89d48c37617e93f1ae7010df3d52c5922394e43';

    // each card will have own image....
    public async tryGetImageAsync(
        imageId: number,
        width: number = 180,
        height: number = 140,
    ): Promise<string | undefined> {
        let imageData = localStorage.getItem(`image:${imageId}`);

        if (imageData !== null) {
            return this.createImage(imageData, width, height);
        }

        var imageSrc = await this.fetchAnImageSrc(this.collectionID[0], width, height);

        imageData = await this.getBase64Image(imageSrc, width, height);
        localStorage.setItem(`image:${imageId}`, imageData);

        return this.createImage(imageData, width, height);
    }

    private onload2promise<T extends { onload: any; onerror: any }>(obj: T): Promise<T> {
        return new Promise((resolve, reject) => {
            obj.onload = () => resolve(obj);
            obj.onerror = reject;
        });
    }

    private fetchAnImageSrc(collectionID: number, width: number, height: number): Promise<any> {
        return new Promise((resolve, reject) => {
            return fetch(
                `https://source.unsplash.com/collection/${collectionID}/${width}x${height}`,
                // `https://source.unsplash.com/collection/${collectionID}/?sig=${Math.floor(Math.random() * 20)}`,
                // `https://source.unsplash.com/collection/${collectionID}/`,
            )
                .then(response => resolve(response.url))
                .catch(() => reject);
        });
    }

    private createImage(base64: string, width: number, height: number) {
        return `<img class="gallery-image" src="${base64}" width="${width}" height="${height}" alt="gallery image"/>`;
    }

    private getBase64Image = (imgSrc: string, width: number, height: number): Promise<string> => {
        return new Promise(async (resolve, reject) => {
            var canvas = document.createElement('canvas');
            var ctx = canvas.getContext('2d');

            var imgElement = document.createElement('img');
            let imgOnPromise = this.onload2promise(imgElement);
            imgElement.src = imgSrc.replace('fm=jpg', 'fm=png');
            imgElement.crossOrigin = 'anonymous';

            canvas.width = width;
            canvas.height = height;

            await imgOnPromise;

            ctx!.drawImage(imgElement, 0, 0);
            var dataURL = canvas.toDataURL('image/png');
            resolve(dataURL);
        });
    };
}
