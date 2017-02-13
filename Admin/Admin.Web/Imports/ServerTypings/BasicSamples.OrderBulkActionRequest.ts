namespace Admin.BasicSamples {
    export interface OrderBulkActionRequest extends Serenity.ServiceRequest {
        OrderIDs?: number[];
    }
}

