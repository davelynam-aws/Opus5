


$(function () {
    // Set placeholder element as a variable for ease of use.
    var placeholderElement = $('#modal-placeholder');
    var customerSelection = $('#CustomerId');

    // Event handler to all buttons with data-toggle equal to ajax-modal
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        // Retrieve URL from the form data.
        var url = $(this).data('url');
        // Ajax GET request receives the modal body from controller/action.
        $.get(url).done(function (data) {
            // Load modal body into placeholder element in DOM.
            placeholderElement.html(data);
            // Display element.
            placeholderElement.find('.modal').modal('show');

        });
    });

    // attach click event handler to an element
    // which is located inside #modal-placeholder
    // and has data-save attribute equal to modal
    // This is done because every event handler is removed
    // after new HTML is loaded with ajax.
    // This method allows us to attach event handler to
    // element and filter the descendants of the element that will trigger the event.
    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();
        // Navigate DOM in order to find a form tag located inside the modal. 
        // Then extract form action url.
        // Then get form data and make it eligible for sending(serialization).
        // Then send the data to server. Once response is received, close the modal.
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();

        // Extract modal body from the response and replace current modal body with the one from response.
        $.post(actionUrl, dataToSend).done(function (data) {
            var newBody = $('.modal-body', data);
            placeholderElement.find('.modal-body').replaceWith(newBody);

            // find IsValid input field and check it's value
            // if it's valid then hide modal window
            var isValid = newBody.find('[name="IsValid"]').val() == 'True';
            if (isValid) {

                // Gets a new collection of active customer names and replaces the existing select list
                AjaxCall();

                // Hides the modal form
                placeholderElement.find('.modal').modal('hide');
            }

            
            /////

        });


        function AjaxCall() {
            $.ajax({
                url: "/Customer/GetActiveCustomers",
                success(response) {
                    parseAndAddDataToForm(response);
                    //GET THE data OBJECT TO DISPLAY CORRECTLY IN THE NEW SELECT LIST!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                   // customerSelection.replaceWith("<select class=\"form-control\" id=\"CustomerId\" asp-items=\"@(new SelectList(" + response + ", \" Id\", \"CustomerName\"))\"><option value=\"\" selected disabled>-- Select Customer Name --</option></select>");
                }
            })
        }

        // Use data obtained by AjaxCall and turn it into a select list and replace a component with the designated ID.
        function parseAndAddDataToForm(response) {
            //$('#CustomerData').empty();
            $('#CustomerId').empty();
            $('#CustomerId').append("<option value=\"\" selected disabled>-- Select Customer Name --</option>")
            $.each(response, function (key, responseValue) {
                var temp = response[key];
                var option = $('<option/>');
                option.attr('value', temp.value).text(temp.text);
                $('#CustomerId').append(option);
            });
            $('#CustomerId').select();
        }
        //<select class="form-control" id="CustomerId" asp-items="@(new SelectList(ViewBag.ActiveCustomers, " Id", "CustomerName"))" >
        //    <option value="" selected disabled>-- Select Customer Name --</option>
        //            </select >
    });


    //placeholderElement.on('click', '[data-save-address="modal"]', function (event) {
    //    event.preventDefault();
    //    // Navigate DOM in order to find a form tag located inside the modal. 
    //    // Then extract form action url.
    //    // Then get form data and make it eligible for sending(serialization).
    //    // Then send the data to server. Once response is received, close the modal.
    //    var form = $(this).parents('.modal').find('form');
    //    var actionUrl = form.attr('action');
    //    var dataToSend = form.serialize();

    //    // Extract modal body from the response and replace current modal body with the one from response.
    //    $.post(actionUrl, dataToSend).done(function (data) {
    //        var newBody = $('.modal-body', data);
    //        placeholderElement.find('.modal-body').replaceWith(newBody);

    //        // find IsValid input field and check it's value
    //        // if it's valid then hide modal window
    //        var isValid = newBody.find('[name="IsValid"]').val() == 'True';
    //        if (isValid) {

    //            // Gets a new collection of active customer names and replaces the existing select list
    //            //AjaxCall();

    //            // Hides the modal form
    //            placeholderElement.find('.modal').modal('hide');

    //        }


    //        /////

    //    });


       
        // Use data obtained by AjaxCall and turn it into a select list and replace a component with the designated ID.
        
        //<select class="form-control" id="CustomerId" asp-items="@(new SelectList(ViewBag.ActiveCustomers, " Id", "CustomerName"))" >
        //    <option value="" selected disabled>-- Select Customer Name --</option>
        //            </select >
    //});


});






















//showCustomerDetails = (url, title) => {
//    $.ajax({
//        type: 'GET',
//        url: url,
//        success: function (res) {
//            $('#form-modal').html(res);
//            $('#form-modal').html(title);
//            //$('#form-modal').modal('show');
//            //// to make popup draggable
//            //$('.modal-dialog').draggable({
//            //    handle: ".modal-header"
//            //});
//        }
//    })
//}



//showInPopup = (url, title) => {
//    $.ajax({
//        type: 'GET',
//        url: url,
//        success: function (res) {
//            $('#form-modal .modal-body').html(res);
//            $('#form-modal .modal-title').html(title);
//            $('#form-modal').modal('show');
//            // to make popup draggable
//            $('.modal-dialog').draggable({
//                handle: ".modal-header"
//            });
//        }
//    })
//}


