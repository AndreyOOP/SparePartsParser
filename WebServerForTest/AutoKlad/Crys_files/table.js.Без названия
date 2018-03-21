var MstarTable=function (data) {
	//this.data=data;
};


MstarTable.prototype.SetCheckboxes = function (form,do_check)
{
	for (var i = 0; i < 500; i++) {
		if (form.elements['row_check_' + i]) {
			form.elements['row_check_' + i].checked = do_check;
		}
		//else break;
	}
};

MstarTable.prototype.ChangeActionSubmit = function (form,new_action)
{
	if (form)
	{
		form.elements["action"].value=new_action;
		form.submit();
	}
	else alert("Form  not found.");
};

// need /libp/jquery/jquery.min.js
MstarTable.prototype.HideTr = function (ii,iGrp)
{
	$('table.datatable tr[pn='+ii+']').hide();
}

MstarTable.prototype.ShowTr = function (ii,iGrp)
{
	var oTr=$('table.datatable tr[pn='+ii+']').html();
	if (oTr==null) {
		oTr=$('table.datatable tr[pn='+iGrp+']').clone();
		oTr.removeAttr("pn").attr("pn",ii).insertAfter("#tr"+ii);
		$('table.datatable tr[pn='+ii+']').show();
	} else {
		$('table.datatable tr[pn='+ii+']').show();
	}

}
//--apstar--end

MstarTable.prototype.ToggleTr = function (i)
{
	oTr=$('table.datatable tr[pn='+i+']');
	if (oTr.css("display")=="none") {
		oTr.show();
		$('#hide_sub_'+i).show();
		$('#show_sub_'+i).hide();
	}
	else {
		oTr.hide();
		$('#hide_sub_'+i).hide();
		$('#show_sub_'+i).show();
	}
}

var mt=new MstarTable();
