namespace HelloWebApi.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
    }

    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class ListController {
        public products;
        constructor(private $http: ng.IHttpService) {
            $http.get("/api/Products")
                .then((response) => {
                    this.products = response.data;
                });
        }
    }

    export class MovieListController {
        public movieList;
        constructor(private $http: ng.IHttpService) {
            $http.get("/api/Movies")
                .then((response) => {
                    this.movieList = response.data;
                });
        }
    }

    export class EditMovieController {
        public title;
        public director;

        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService) {
            $http.get("/api/movies" + this.$stateParams["id"])
                .then((response) => {
                let data: any = response
                    this.title = data["title"];
                    this.director = data["director"];
                });
        }
        editMovie() {
            let data = {
                title: this.title,
                director: this.director
            };
            this.$http.put("/api/Movies/" + this.$stateParams["id"], data)
                .then((s) => {
                   
                }, (e) => {
                });
        }

    }

    export class AddMovieController {
        public title;
        public director;
        public message;
        constructor(private $http: ng.IHttpService, private $location: ng.ILocationService) {
        }
        AddMovie() {
            let data = {
                title: this.title,
                director: this.director
            };
            this.$http.post("/api/Movies", data)
                .then((s) => {
                    //this.title = " ";
                    //this.director = " ";
                    //this.message = "Movie created successfully";
                    this.$location.path("/movie");
                }, (e) => {
                });
        }
    }

}
