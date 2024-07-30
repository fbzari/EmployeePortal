(function () {
    'use strict';

    // Form validation script
    const forms = document.querySelectorAll('.requires-validation');
    const formItems = document.querySelector(".form-content .form-items");


    function toggleScrollbar() {
        console.log('scrollHeight:', formItems.scrollHeight, 'clientHeight:', formItems.clientHeight);
        if (formItems.scrollHeight > formItems.clientHeight) {
            formItems.style.overflowY = 'scroll';
        } else {
            console.log(formItems);
            formItems.style.overflowY = 'hidden';
        }
    }

    Array.from(forms).forEach(function (form) {
        form.addEventListener('submit', function (event) {
            if (!form.checkValidity()) {
                alert("stop")
                event.preventDefault();
                event.stopPropagation();
            }

            form.classList.add('was-validated');
            toggleScrollbar();

        }, false);

    });

    // Scrollbar toggle script

    $(document).ready(function () {

        $('#EmployeeTable').DataTable({
            stateSave: true,
            "bDestroy": true,
            stateDuration: -1, //
            lengthMenu: [
                [5, 10, 15, 20, 25, 50, -1],
                [5, 10, 15, 20, 25, 50, 'All']
            ],
            language: {
                info: "Showing _START_ to _END_ of _TOTAL_ Employee(s)",
                infoFiltered: "(filtered from _MAX_ total employee(s)",
                lengthMenu: "Display _MENU_ employee(s) per page",
                searchPlaceholder: "Type here to search..",
                search: "Search employee(s): ",
                stateSave: true
            },
            order: [[1, 'asc']],
            columnDefs: [
                {
                    targets: 1,
                    orderable: true,
                    orderData: [1],
                    orderSequence: ['asc', 'desc']
                },
                {
                    targets: 5,
                    className: "center-column",
                    orderable: false,
                    searchable:false
                }
            ]
        });
    });

})();
