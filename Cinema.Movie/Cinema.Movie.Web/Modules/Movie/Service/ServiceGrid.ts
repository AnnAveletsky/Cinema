namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class ServiceGrid extends Serenity.EntityGrid<ServiceRow, any> {
        protected getColumnsKey() { return 'Movie.Service'; }
        protected getDialogType() { return ServiceDialog; }
        protected getIdProperty() { return ServiceRow.idProperty; }
        protected getLocalTextPrefix() { return ServiceRow.localTextPrefix; }
        protected getService() { return ServiceService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getColumns(): Slick.Column[] {
            var columns = super.getColumns();
            var fld = ServiceRow.Fields;

            Q.first(columns, x => x.field == fld.Api).format =
                ctx => `<a href="javascript:;" class="btn btn-info">${Q.htmlEncode(ctx.value)}</a>`;

            return columns;
        }

        protected onClick(e: JQueryEventObject, row: number, cell: number): void {

            // let base grid handle clicks for its edit links
            super.onClick(e, row, cell);

            // if base grid already handled, we shouldn"t handle it again
            if (e.isDefaultPrevented()) {
                return;
            }

            // get reference to current item
            var item = this.itemAt(row);

            // get reference to clicked element
            var target = $(e.target);

            if (target.hasClass("btn-info")) {
                e.preventDefault();
                console.log("click");
                var data = Q.serviceCall({
                    service: '/Movie/Service/GetMovies?id=' + item.ServiceId,
                }).done((data) => {
                    if (data != null) {
                        let message = Q.format(
                            "<p>No data</p>"+data,
                            Q.htmlEncode(item.Name));

                        Q.confirm(message, () => {
                        },
                            {
                                htmlEncode: false,
                            });
                        //new Movie.MovieDialog().loadByIdAndOpenDialog(data);
                    } else {
                        let message = Q.format(
                            "<p>No data</p>",
                            Q.htmlEncode(item.Name));

                        Q.confirm(message, () => {
                        },
                            {
                                htmlEncode: false,
                            });
                    }
                    });

                
               
            }
        }
    }
}