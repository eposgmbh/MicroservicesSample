export class Note {
    constructor(
        public id: string = null, public text: string = '',
        public author: string = '', public updated?: Date
    ) {
        if (!updated) {
            this.updated = new Date();
        }
    }
}
