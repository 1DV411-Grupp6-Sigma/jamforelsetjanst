//Compare module

    angular.module('compare', [])
        .controller('compareViewModel', function() {
            var vm = this;
            //List that contains selected OU
            vm.selectedOuList = [];
            vm.hello = "Hello from compareViewModel";
            vm.addToCompareList = function(organisationalUnit) {
                selectedOuList.push(organisationalUnit);
            };
        });



//Module for testing

    mainModule.controller('andreasCategoryViewModel', function(compare) {
        var vm = this;
        vm.hello = "Hello!";
        vm.compare.addToCompareList("ID");
        vm.list = compare.selectedOuList;
    });

