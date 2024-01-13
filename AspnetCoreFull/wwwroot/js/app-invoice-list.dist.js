"use strict";$(function(){var e,a=$(".invoice-list-table");a.length&&(e=a.DataTable({ajax:assetsPath+"json/invoice-list.json",columns:[{data:""},{data:"invoice_id"},{data:"invoice_status"},{data:"issued_date"},{data:"client_name"},{data:"total"},{data:"balance"},{data:"invoice_status"},{data:"action"}],columnDefs:[{className:"control",responsivePriority:2,searchable:!1,targets:0,render:function(e,a,t,s){return""}},{targets:1,render:function(e,a,t,s){return'<a href="/Apps/Invoice/Preview">#'+t.invoice_id+"</a>"}},{targets:2,render:function(e,a,t,s){var n=t.invoice_status,r=t.due_date;return"<span data-bs-toggle='tooltip' data-bs-html='true' title='<span>"+n+"<br> Balance: "+t.balance+"<br> Due Date: "+r+"</span>'>"+{Sent:'<span class="badge badge-center rounded-pill bg-label-secondary w-px-30 h-px-30"><i class="bx bx-paper-plane bx-xs"></i></span>',Draft:'<span class="badge badge-center rounded-pill bg-label-primary w-px-30 h-px-30"><i class="bx bxs-save bx-xs"></i></span>',"Past Due":'<span class="badge badge-center rounded-pill bg-label-danger w-px-30 h-px-30"><i class="bx bx-info-circle bx-xs"></i></span>',"Partial Payment":'<span class="badge badge-center rounded-pill bg-label-success w-px-30 h-px-30"><i class="bx bx-adjust bx-xs"></i></span>',Paid:'<span class="badge badge-center rounded-pill bg-label-warning w-px-30 h-px-30"><i class="bx bx-pie-chart-alt bx-xs"></i></span>',Downloaded:'<span class="badge badge-center rounded-pill bg-label-info w-px-30 h-px-30"><i class="bx bx-down-arrow-circle bx-xs"></i></span>'}[n]+"</span>"}},{targets:3,responsivePriority:4,render:function(e,a,t,s){var n=t.client_name,r=t.service,l=t.avatar_image,o=Math.floor(11*Math.random())+1;return'<div class="d-flex justify-content-start align-items-center"><div class="avatar-wrapper"><div class="avatar avatar-sm me-2">'+(!0===l?'<img src="'+assetsPath+"img/avatars/"+(o+".png")+'" alt="Avatar" class="rounded-circle">':'<span class="avatar-initial rounded-circle bg-label-'+["success","danger","warning","info","dark","primary","secondary"][Math.floor(6*Math.random())]+'">'+(l=(((l=(n=t.client_name).match(/\b\w/g)||[]).shift()||"")+(l.pop()||"")).toUpperCase())+"</span>")+'</div></div><div class="d-flex flex-column"><a href="/Pages/Profile/User" class="text-body text-truncate fw-semibold">'+n+'</a><small class="text-truncate text-muted">'+r+"</small></div></div>"}},{targets:4,render:function(e,a,t,s){t=t.total;return'<span class="d-none">'+t+"</span>$"+t}},{targets:5,render:function(e,a,t,s){t=new Date(t.due_date);return'<span class="d-none">'+moment(t).format("YYYYMMDD")+"</span>"+moment(t).format("DD MMM YYYY")}},{targets:6,orderable:!1,render:function(e,a,t,s){t=t.balance;return 0===t?'<span class="badge bg-label-success"> Paid </span>':'<span class="d-none">'+t+"</span>"+t}},{targets:7,visible:!1},{targets:-1,title:"Actions",searchable:!1,orderable:!1,render:function(e,a,t,s){return'<div class="d-flex align-items-center"><a href="javascript:;" data-bs-toggle="tooltip" class="text-body" data-bs-placement="top" title="Send Mail"><i class="bx bx-send mx-1"></i></a><a href=""/Apps/Invoice/Preview" data-bs-toggle="tooltip" class="text-body" data-bs-placement="top" title="Preview Invoice"><i class="bx bx-show mx-1"></i></a><div class="dropdown"><a href="javascript:;" class="btn dropdown-toggle hide-arrow text-body p-0" data-bs-toggle="dropdown"><i class="bx bx-dots-vertical-rounded"></i></a><div class="dropdown-menu dropdown-menu-end"><a href="javascript:;" class="dropdown-item">Download</a><a href=""/Apps/Invoice/Edit" class="dropdown-item">Edit</a><a href="javascript:;" class="dropdown-item">Duplicate</a><div class="dropdown-divider"></div><a href="javascript:;" class="dropdown-item delete-record text-danger">Delete</a></div></div></div>'}}],order:[[1,"desc"]],dom:'<"row ms-2 me-3"<"col-12 col-md-6 d-flex align-items-center justify-content-center justify-content-md-start gap-2"l<"dt-action-buttons text-xl-end text-lg-start text-md-end text-start mt-md-0 mt-3"B>><"col-12 col-md-6 d-flex align-items-center justify-content-end flex-column flex-md-row pe-3 gap-md-2"f<"invoice_status mb-3 mb-md-0">>>t<"row mx-2"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>',language:{sLengthMenu:"_MENU_",search:"",searchPlaceholder:"Search Invoice"},buttons:[{text:'<i class="bx bx-plus me-md-1"></i><span class="d-md-inline-block d-none">Create Invoice</span>',className:"btn btn-primary",action:function(e,a,t,s){window.location="/Apps/Invoice/Add"}}],responsive:{details:{display:$.fn.dataTable.Responsive.display.modal({header:function(e){return"Details of "+e.data().full_name}}),type:"column",renderer:function(e,a,t){t=$.map(t,function(e,a){return""!==e.title?'<tr data-dt-row="'+e.rowIndex+'" data-dt-column="'+e.columnIndex+'"><td>'+e.title+":</td> <td>"+e.data+"</td></tr>":""}).join("");return!!t&&$('<table class="table"/><tbody />').append(t)}}},initComplete:function(){this.api().columns(7).every(function(){var a=this,t=$('<select id="UserRole" class="form-select"><option value=""> Select Status </option></select>').appendTo(".invoice_status").on("change",function(){var e=$.fn.dataTable.util.escapeRegex($(this).val());a.search(e?"^"+e+"$":"",!0,!1).draw()});a.data().unique().sort().each(function(e,a){t.append('<option value="'+e+'" class="text-capitalize">'+e+"</option>")})})}})),a.on("draw.dt",function(){[].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]')).map(function(e){return new bootstrap.Tooltip(e,{boundary:document.body})})}),$(".invoice-list-table tbody").on("click",".delete-record",function(){e.row($(this).parents("tr")).remove().draw()}),setTimeout(()=>{$(".dataTables_filter .form-control").removeClass("form-control-sm"),$(".dataTables_length .form-select").removeClass("form-select-sm")},300)});