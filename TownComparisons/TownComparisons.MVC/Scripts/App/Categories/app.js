//Category
(function () {
    app.controller("CategoryViewModel", function CategoryViewModel() {
        this.pageTitle = "Kategori";
        this.categories = [
            {
                name: "Grundskola",
                url: "~/Home/Category/1"
            },
            {
                name: "Gymnasieskola",
                url: "~/Home/Category/2"
            },
            {
                name: "Äldreomsorg",
                url: "~/Home/Category/3"
            }
           
        ];

    });
})();

