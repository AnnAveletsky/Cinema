var request = function () {
    var self = this;
    self.url = "http://localhost:49999/api/";

    self.getSite = function (done, fail) {
        return self.get("page", "", done, fail);
    }
    self.get = function (url, data, done, fail) {
        return self.ajax("GET", self.url + url, data, done, fail);
    }
    self.post = function (url, data, done, fail) {
        return self.ajax("POST", self.url + url, data, done, fail);
    }
    self.ajax = function (type, url, data, done, fail) {
        $.ajax({
            type: type,
            url: url,
            data: data,
        })
        .done(function (response) {
            if (done) {
                return done(response);
            }
            return response;
        })
        .fail(function (response) {
            if (fail) {
                return fail(response);
            }
            return response;
        });
    }

    
    return {
        getSite: self.getSite,
    }
}

