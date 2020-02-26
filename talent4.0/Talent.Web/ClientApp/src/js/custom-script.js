window.ATL_JQ_PAGE_PROPS = {
    "triggerFunction": function (showCollectorDialog) {
        $(document).on("click", "#JiraTrigger", function(e) {
            window.ATL_JQ_PAGE_PROPS.fieldValues.fullname = $("#nameSurveyLabel").val();
            window.ATL_JQ_PAGE_PROPS.fieldValues.email = $("#emailSurveyLabel").val();
            e.preventDefault();
            showCollectorDialog();              
        });
    },
    //to add pre compilated fields
    fieldValues:
    {
        description: '',

        //TODO - GET name from tab UTENTI: ute_nome (logged user)
        fullname: '',

        //TODO - GET email from tab UTENTI: ute_mail (logged user)
        email: '',

        //leave the default priority on ?
        priority: '?'
    }
};