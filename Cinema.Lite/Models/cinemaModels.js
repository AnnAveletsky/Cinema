var cinemaModel = function (data) {
    var self = this;
    self.model = ko.viewmodel.toModel(data);
    
    self.getShortDescription = function (movie) {
        return movie.Description.toString().substr(0,100)+'...';
    }
    return {
        model: self.model,
        getTitle: self.getTitle,
        getShortDescription: self.getShortDescription
    }
}