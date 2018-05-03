export class Note {
    constructor(
        public id?: string, public text?: string,
        public author?: string, public updated?: Date
    ) {
        if (!updated) {
            this.updated = new Date();
        }
    }
}
