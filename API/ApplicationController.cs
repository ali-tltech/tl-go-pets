using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TLCAREERSCORE.Models;
using TLCAREERSCORE.Services;
using static System.Net.Mime.MediaTypeNames;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace TLCAREERSCORE.API
{
   
    [Route("api/[controller]")]
    [ApiController]
    
    public class ApplicationController : ControllerBase
    {
       
        private readonly IApplication _Application;

        private readonly string _url;

        public ApplicationController(IApplication Applications, IConfiguration configuration)//constructor
        {
            _Application = Applications;
            _url = configuration.GetConnectionString("url_api");
        }
        private static int saveCount = 0;

        [HttpPost]


        public async Task<IActionResult> PostAsync([FromBody] Models.Application application)
        {
            
            // Extract the necessary information from the model
            string emailTo = application.email;
            string subject = "Gopetz,Find you perfect pet.";
            string body = $@"
<!DOCTYPE html>
<html xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" lang=""en"">

<head>
	<title></title>
	<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">
	<meta name=""viewport"" content=""width=device-width, initial-scale=1.0""><!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]--><!--[if !mso]><!-->
	<link href=""https://fonts.googleapis.com/css?family=Merriweather"" rel=""stylesheet"" type=""text/css""><!--<![endif]-->
	<style>
		* {{
			box-sizing: border-box;
		}}

		body {{
			margin: 0;
			padding: 0;
		}}

		a[x-apple-data-detectors] {{
			color: inherit !important;
			text-decoration: inherit !important;
		}}

		#MessageViewBody a {{
			color: inherit;
			text-decoration: none;
		}}

		p {{
			line-height: inherit
		}}

		.desktop_hide,
		.desktop_hide table {{
			mso-hide: all;
			display: none;
			max-height: 0px;
			overflow: hidden;
		}}

		.image_block img+div {{
			display: none;
		}}

		@media (max-width:768px) {{
			.row-8 .column-1 .block-1.image_block img {{
				display: inline-block !important;
			}}

			.row-8 .column-1 .block-1.image_block .alignment {{
				text-align: center !important;
			}}
		}}

		@media (max-width:820px) {{
			.row-content {{
				width: 100% !important;
			}}

			.mobile_hide {{
				display: none;
			}}

			.stack .column {{
				width: 100%;
				display: block;
			}}

			.mobile_hide {{
				min-height: 0;
				max-height: 0;
				max-width: 0;
				overflow: hidden;
				font-size: 0px;
			}}

			.desktop_hide,
			.desktop_hide table {{
				display: table !important;
				max-height: none !important;
			}}

			.row-8 .column-1,
			.row-8 .column-2 {{
				padding: 0 0 5px !important;
			}}

			.row-10 .column-2 {{
				padding: 5px 0 !important;
			}}
		}}
	</style>
</head>

<body style=""background-color: #f9f9f9; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;"">
	<table class=""nl-container"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f9f9f9;"">
		<tbody>
			<tr>
				<td>
					<table class=""row row-1"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #fff5f5; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<div class=""spacer_block block-1"" style=""height:20px;line-height:20px;font-size:1px;"">&#8202;</div>
													<table class=""image_block block-2"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/Integrators/BeeProAgency/1003843_988669/Logo%20Design%20-%20Variation%20Logo.png"" style=""display: block; height: auto; border: 0; width: 240px; max-width: 100%;"" width=""240"" alt=""Alternate text"" title=""Alternate text""></div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-2"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; background-image: url('https://d1oco4z2z1fhwp.cloudfront.net/templates/default/1236/Background_section_2.gif'); background-repeat: no-repeat; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""text_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"" style=""padding-bottom:5px;padding-left:10px;padding-right:10px;padding-top:10px;"">
																<div style=""font-family: sans-serif"">
																	<div class style=""font-size: 14px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 16.8px; color: #ad0f0f; line-height: 1.2;"">
																		<p style=""margin: 0; font-size: 14px; text-align: center; mso-line-height-alt: 16.8px;""><em><strong>Find your Perfect Companion through Gopetz.</strong></em></p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
													<table class=""text_block block-2"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"" style=""padding-bottom:5px;padding-left:10px;padding-right:10px;padding-top:10px;"">
																<div style=""font-family: sans-serif"">
																	<div class style=""font-size: 14px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 16.8px; color: #34495e; line-height: 1.2;"">
																		<p style=""margin: 0; font-size: 14px; text-align: center; mso-line-height-alt: 16.8px;""><strong><span style=""font-size:46px;""><span style=""font-size:38px;"">THANK YOU FOR SUBSCRIBING</span></span></strong></p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
													<div class=""spacer_block block-3"" style=""height:10px;line-height:10px;font-size:1px;"">&#8202;</div>
													<table class=""text_block block-4"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"" style=""padding-bottom:10px;padding-left:60px;padding-right:60px;padding-top:10px;"">
																<div style=""font-family: sans-serif"">
																	<div class style=""font-size: 12px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 21.6px; color: #8d8d8d; line-height: 1.8;"">
																		<p style=""margin: 0; font-size: 14px; text-align: center; mso-line-height-alt: 25.2px;"">Download the Gopetz mobile application on your smartphone or tablet and unlock a range of features and benefits tailored to meet your pet-related needs. Whether you're a passionate pet lover seeking valuable resources or a pet store owner looking to connect with a wider audience, Gopetz has you covered.</p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
													<div class=""spacer_block block-5"" style=""height:15px;line-height:15px;font-size:1px;"">&#8202;</div>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-3"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""33.333333333333336%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; background-color: #ff87ca; border-left: 7px solid #FFFFFF; border-right: 7px solid #FFFFFF; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-bottom: 0px;"">
													<table class=""text_block block-1"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family: sans-serif"">
																	<div class style=""font-size: 12px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 14.399999999999999px; color: #ffffff; line-height: 1.2;"">
																		<p style=""margin: 0; font-size: 16px; text-align: center; mso-line-height-alt: 19.2px;""><strong>FURRY</strong></p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
													<table class=""image_block block-2"" width=""100%"" border=""0"" cellpadding=""15"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/Integrators/BeeProAgency/1003843_988669/Group%202.png"" style=""display: block; height: auto; border: 0; width: 223px; max-width: 100%;"" width=""223"" alt=""I'm an image"" title=""I'm an image""></div>
															</td>
														</tr>
													</table>
													<table class=""button_block block-3"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div class=""alignment"" align=""center""><!--[if mso]><v:roundrect xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:w=""urn:schemas-microsoft-com:office:word"" href=""#"" style=""height:45px;width:76px;v-text-anchor:middle;"" arcsize=""9%"" strokeweight=""1.5pt"" strokecolor=""#FFFFFF"" fill=""false""><w:anchorlock/><v:textbox inset=""0px,0px,0px,0px""><center style=""color:#ffffff; font-family:Tahoma, Verdana, sans-serif; font-size:16px""><![endif]--><a href=""#"" target=""_blank"" style=""text-decoration:none;display:inline-block;color:#ffffff;background-color:transparent;border-radius:4px;width:auto;border-top:2px solid #FFFFFF;font-weight:undefined;border-right:2px solid #FFFFFF;border-bottom:2px solid #FFFFFF;border-left:2px solid #FFFFFF;padding-top:5px;padding-bottom:5px;font-family:Roboto, Tahoma, Verdana, Segoe, sans-serif;font-size:16px;text-align:center;mso-border-alt:none;word-break:keep-all;""><span style=""padding-left:20px;padding-right:20px;font-size:16px;display:inline-block;letter-spacing:normal;""><span style=""word-break: break-word; line-height: 32px;"">BUY</span></span></a><!--[if mso]></center></v:textbox></v:roundrect><![endif]--></div>
															</td>
														</tr>
													</table>
												</td>
												<td class=""column column-2"" width=""33.333333333333336%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; background-color: #7179f6; border-left: 7px solid #FFFFFF; border-right: 7px solid #FFFFFF; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-bottom: 0px;"">
													<table class=""text_block block-1"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family: sans-serif"">
																	<div class style=""font-size: 12px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 14.399999999999999px; color: #ffffff; line-height: 1.2;"">
																		<p style=""margin: 0; font-size: 16px; text-align: center; mso-line-height-alt: 19.2px;""><strong>FRIEND</strong></p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
													<table class=""image_block block-2"" width=""100%"" border=""0"" cellpadding=""15"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/Integrators/BeeProAgency/1003843_988669/new%20home.png"" style=""display: block; height: auto; border: 0; width: 223px; max-width: 100%;"" width=""223"" alt=""I'm an image"" title=""I'm an image""></div>
															</td>
														</tr>
													</table>
													<table class=""button_block block-3"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div class=""alignment"" align=""center""><!--[if mso]><v:roundrect xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:w=""urn:schemas-microsoft-com:office:word"" href=""#"" style=""height:45px;width:81px;v-text-anchor:middle;"" arcsize=""9%"" strokeweight=""1.5pt"" strokecolor=""#FFFFFF"" fill=""false""><w:anchorlock/><v:textbox inset=""0px,0px,0px,0px""><center style=""color:#ffffff; font-family:Tahoma, Verdana, sans-serif; font-size:16px""><![endif]--><a href=""#"" target=""_blank"" style=""text-decoration:none;display:inline-block;color:#ffffff;background-color:transparent;border-radius:4px;width:auto;border-top:2px solid #FFFFFF;font-weight:undefined;border-right:2px solid #FFFFFF;border-bottom:2px solid #FFFFFF;border-left:2px solid #FFFFFF;padding-top:5px;padding-bottom:5px;font-family:Roboto, Tahoma, Verdana, Segoe, sans-serif;font-size:16px;text-align:center;mso-border-alt:none;word-break:keep-all;""><span style=""padding-left:20px;padding-right:20px;font-size:16px;display:inline-block;letter-spacing:normal;""><span style=""word-break: break-word; line-height: 32px;"">SELL</span></span></a><!--[if mso]></center></v:textbox></v:roundrect><![endif]--></div>
															</td>
														</tr>
													</table>
												</td>
												<td class=""column column-3"" width=""33.333333333333336%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; background-color: #50b8a1; border-left: 7px solid #FFFFFF; border-right: 7px solid #FFFFFF; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-bottom: 0px;"">
													<table class=""text_block block-1"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family: sans-serif"">
																	<div class style=""font-size: 12px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 14.399999999999999px; color: #ffffff; line-height: 1.2;"">
																		<p style=""margin: 0; font-size: 16px; text-align: center; mso-line-height-alt: 19.2px;""><strong>FOREVER</strong></p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
													<table class=""image_block block-2"" width=""100%"" border=""0"" cellpadding=""15"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/Integrators/BeeProAgency/1003843_988669/Group%204.png"" style=""display: block; height: auto; border: 0; width: 223px; max-width: 100%;"" width=""223"" alt=""I'm an image"" title=""I'm an image""></div>
															</td>
														</tr>
													</table>
													<table class=""button_block block-3"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div class=""alignment"" align=""center""><!--[if mso]><v:roundrect xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:w=""urn:schemas-microsoft-com:office:word"" href=""#"" style=""height:45px;width:102px;v-text-anchor:middle;"" arcsize=""9%"" strokeweight=""1.5pt"" strokecolor=""#FFFFFF"" fill=""false""><w:anchorlock/><v:textbox inset=""0px,0px,0px,0px""><center style=""color:#ffffff; font-family:Tahoma, Verdana, sans-serif; font-size:16px""><![endif]--><a href=""#"" target=""_blank"" style=""text-decoration:none;display:inline-block;color:#ffffff;background-color:transparent;border-radius:4px;width:auto;border-top:2px solid #FFFFFF;font-weight:undefined;border-right:2px solid #FFFFFF;border-bottom:2px solid #FFFFFF;border-left:2px solid #FFFFFF;padding-top:5px;padding-bottom:5px;font-family:Roboto, Tahoma, Verdana, Segoe, sans-serif;font-size:16px;text-align:center;mso-border-alt:none;word-break:keep-all;""><span style=""padding-left:20px;padding-right:20px;font-size:16px;display:inline-block;letter-spacing:normal;""><span style=""word-break: break-word; line-height: 32px;"">&nbsp;ADOPT</span></span></a><!--[if mso]></center></v:textbox></v:roundrect><![endif]--></div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-4"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<div class=""spacer_block block-1"" style=""height:25px;line-height:25px;font-size:1px;"">&#8202;</div>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-5"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""divider_block block-1"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div class=""alignment"" align=""center"">
																	<table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" width=""95%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
																		<tr>
																			<td class=""divider_inner"" style=""font-size: 1px; line-height: 1px; border-top: 1px solid #ECE9E9;""><span>&#8202;</span></td>
																		</tr>
																	</table>
																</div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-6"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""text_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"" style=""padding-bottom:5px;padding-left:15px;padding-right:10px;padding-top:10px;"">
																<div style=""font-family: sans-serif"">
																	<div class style=""font-size: 14px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 16.8px; color: #34495e; line-height: 1.2;"">
																		<p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 16.8px;""><strong>Here's why GoPetz is the ultimate mobile application for pet lovers and pet stores:</strong></p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-7"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""divider_block block-1"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div class=""alignment"" align=""center"">
																	<table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" width=""95%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
																		<tr>
																			<td class=""divider_inner"" style=""font-size: 1px; line-height: 1px; border-top: 1px solid #ECE9E9;""><span>&#8202;</span></td>
																		</tr>
																	</table>
																</div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-8"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""25%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-left: 20px; padding-top: 25px; vertical-align: middle; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""image_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""width:100%;padding-right:0px;padding-left:0px;"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/Integrators/BeeProAgency/1003843_988669/gopetz%20banner%202.jpg"" style=""display: block; height: auto; border: 0; width: 180px; max-width: 100%;"" width=""180"" alt=""I'm an image"" title=""I'm an image""></div>
															</td>
														</tr>
													</table>
												</td>
												<td class=""column column-2"" width=""75%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-left: 30px; padding-top: 5px; vertical-align: middle; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""text_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"" style=""padding-bottom:10px;padding-left:15px;padding-right:15px;padding-top:10px;"">
																<div style=""font-family: sans-serif"">
																	<div class style=""font-size: 12px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 21.6px; color: #8d8d8d; line-height: 1.8;"">
																		<p style=""margin: 0; mso-line-height-alt: 21.6px;"">&nbsp;</p>
																		<p style=""margin: 0; text-align: left; mso-line-height-alt: 25.2px;""><span style=""font-size:14px;"">Exclusive Offers and Deals: Enjoy exclusive deals, discounts, and promotions from partnered pet stores and service providers. As a GoPetz user, you'll have access to special offers on pet food, accessories, grooming services, veterinary care, and more. Save money while providing the best for your furry friends.</span></p>
																		<p style=""margin: 0; mso-line-height-alt: 21.6px;"">&nbsp;</p>
																		<p style=""margin: 0; mso-line-height-alt: 21.6px;"">&nbsp;</p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-9"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""divider_block block-1"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div class=""alignment"" align=""center"">
																	<table border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" width=""95%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
																		<tr>
																			<td class=""divider_inner"" style=""font-size: 1px; line-height: 1px; border-top: 1px solid #ECE9E9;""><span>&#8202;</span></td>
																		</tr>
																	</table>
																</div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-10"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""75%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<div class=""spacer_block block-1"" style=""height:20px;line-height:20px;font-size:1px;"">&#8202;</div>
													<table class=""text_block block-2"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"" style=""padding-bottom:10px;padding-left:15px;padding-right:15px;padding-top:10px;"">
																<div style=""font-family: sans-serif"">
																	<div class style=""font-size: 12px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 21.6px; color: #8d8d8d; line-height: 1.8;"">
																		<p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 25.2px;"">Pet Store Directory: Discover a vast network of pet stores in your area and beyond. Whether you're looking for specialty pet boutiques, veterinary clinics, grooming salons, or pet-friendly establishments, the GoPetz app offers a comprehensive directory to connect you with trusted and reliable pet-related businesses.</p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
												</td>
												<td class=""column column-2"" width=""25%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-right: 15px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""image_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""width:100%;padding-right:0px;padding-left:0px;"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/Integrators/BeeProAgency/1003843_988669/gopets%20banner%203.jpg"" style=""display: block; height: auto; border: 0; width: 185px; max-width: 100%;"" width=""185"" alt=""I'm an image"" title=""I'm an image""></div>
															</td>
														</tr>
													</table>
													<div class=""spacer_block block-2 mobile_hide"" style=""height:40px;line-height:40px;font-size:1px;"">&#8202;</div>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-11"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffe5f4; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""image_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""width:100%;padding-right:0px;padding-left:0px;"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/Integrators/BeeProAgency/1003843_988669/new%20logo.png"" style=""display: block; height: auto; border: 0; width: 160px; max-width: 100%;"" width=""160"" alt=""I'm an image"" title=""I'm an image""></div>
															</td>
														</tr>
													</table>
													<table class=""text_block block-2"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family: sans-serif"">
																	<div class style=""font-size: 12px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 14.399999999999999px; color: #555555; line-height: 1.2;"">
																		<p style=""margin: 0; font-size: 14px; text-align: center; mso-line-height-alt: 16.8px;"">Download the Gopetz mobile application on your smartphone or tablet and unlock a range of features and benefits tailored to meet your pet-related needs.</p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-12"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffe5f4; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""image_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""width:100%;padding-right:0px;padding-left:0px;"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/Integrators/BeeProAgency/1003843_988669/Banner-Graphics-01.png"" style=""display: block; height: auto; border: 0; width: 320px; max-width: 100%;"" width=""320"" alt=""I'm an image"" title=""I'm an image""></div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-13"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffffff; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""50%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<div class=""spacer_block block-1 mobile_hide"" style=""height:40px;line-height:40px;font-size:1px;"">&#8202;</div>
													<table class=""text_block block-2"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"" style=""padding-bottom:5px;padding-left:15px;padding-right:10px;padding-top:10px;"">
																<div style=""font-family: sans-serif"">
																	<div class style=""font-size: 14px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 16.8px; color: #34495e; line-height: 1.2;"">
																		<p style=""margin: 0; font-size: 14px; text-align: left; mso-line-height-alt: 16.8px;""><span style=""font-size:34px;""><strong><span style>FIND PETS AT YOUR NEAREST.</span></strong></span></p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
													<div class=""spacer_block block-3"" style=""height:0px;line-height:0px;font-size:1px;"">&#8202;</div>
												</td>
												<td class=""column column-2"" width=""50%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""image_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""width:100%;padding-right:0px;padding-left:0px;"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d1oco4z2z1fhwp.cloudfront.net/templates/default/1236/parade-route.png"" style=""display: block; height: auto; border: 0; width: 320px; max-width: 100%;"" width=""320"" alt=""I'm an image"" title=""I'm an image""></div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-14"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #ffd0ea; background-image: url('https://d1oco4z2z1fhwp.cloudfront.net/templates/default/1236/Stay_Safe.gif'); background-position: center top; background-repeat: no-repeat; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<div class=""spacer_block block-1"" style=""height:55px;line-height:55px;font-size:1px;"">&#8202;</div>
													<table class=""text_block block-2"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"" style=""padding-bottom:10px;padding-left:60px;padding-right:60px;padding-top:10px;"">
																<div style=""font-family: serif"">
																	<div class style=""font-size: 12px; font-family: 'Merriwheater', 'Georgia', serif; mso-line-height-alt: 18px; color: #555555; line-height: 1.5;"">
																		<p style=""margin: 0; font-size: 14px; text-align: center; mso-line-height-alt: 45px;""><span style=""font-size:30px;"">Thank you for your interest in GoPetz, where pets are at the heart of everything we do. Stay connected with us for updates, new features, and exciting opportunities to connect with fellow pet lovers and pet stores.</span></p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
													<table class=""button_block block-3"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div class=""alignment"" align=""center""><!--[if mso]><v:roundrect xmlns:v=""urn:schemas-microsoft-com:vml"" xmlns:w=""urn:schemas-microsoft-com:office:word"" href=""#"" style=""height:42px;width:196px;v-text-anchor:middle;"" arcsize=""10%"" stroke=""false"" fillcolor=""#7179f6""><w:anchorlock/><v:textbox inset=""0px,0px,0px,0px""><center style=""color:#ffffff; font-family:Tahoma, Verdana, sans-serif; font-size:16px""><![endif]--><a href=""#"" target=""_blank"" style=""text-decoration:none;display:inline-block;color:#ffffff;background-color:#7179f6;border-radius:4px;width:auto;border-top:0px solid transparent;font-weight:undefined;border-right:0px solid transparent;border-bottom:0px solid transparent;border-left:0px solid transparent;padding-top:5px;padding-bottom:5px;font-family:Roboto, Tahoma, Verdana, Segoe, sans-serif;font-size:16px;text-align:center;mso-border-alt:none;word-break:keep-all;""><span style=""padding-left:50px;padding-right:50px;font-size:16px;display:inline-block;letter-spacing:normal;""><span style=""margin: 0; word-break: break-word; line-height: 32px;"">View on store</span></span></a><!--[if mso]></center></v:textbox></v:roundrect><![endif]--></div>
															</td>
														</tr>
													</table>
													<div class=""spacer_block block-4"" style=""height:55px;line-height:55px;font-size:1px;"">&#8202;</div>
													<table class=""heading_block block-5"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<h3 style=""margin: 0; color: #8a3c90; direction: ltr; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; font-size: 24px; font-weight: 400; letter-spacing: normal; line-height: 120%; text-align: center; margin-top: 0; margin-bottom: 0;""><span class=""tinyMce-placeholder"">Follow us on <a href=""https://www.facebook.com/profile.php?id=100091325113320"" target=""_blank"" title=""facebook"" rel=""noopener"" style=""text-decoration: underline; color: #8a3c90;"">facebook </a>. &nbsp;<a href=""https://www.instagram.com/gopetz_petz/"" target=""_blank"" title=""instagram"" rel=""noopener"" style=""text-decoration: underline; color: #8a3c90;"">instagram </a>. &nbsp;<a href=""https://www.linkedin.com/in/gopetz-petz-4b673026b/&quot"" target=""_blank"" title=""linkedin"" rel=""noopener"" style=""text-decoration: underline; color: #8a3c90;"">linkedin</a>. &nbsp;<a href=""https://in.pinterest.com/gopetz235/"" target=""_blank"" title=""pinterest"" style=""text-decoration: underline; color: #8a3c90;"" rel=""noopener"">pinterest </a>.&nbsp;</span></h3>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-15"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #e6eaff; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""50%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: middle; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""text_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"" style=""padding-bottom:10px;padding-left:30px;padding-right:10px;padding-top:10px;"">
																<div style=""font-family: sans-serif"">
																	<div class style=""font-size: 12px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 24px; color: #9c2121; line-height: 2;"">
																		<p style=""margin: 0; font-size: 14px; mso-line-height-alt: 28px;"">Copyright © 2023 TL TECHNOLOGIES PRIVATE LIMITED&nbsp;</p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
												</td>
												<td class=""column column-2"" width=""50%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: middle; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""image_block block-1"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"" style=""width:100%;padding-right:0px;padding-left:0px;"">
																<div class=""alignment"" align=""center"" style=""line-height:10px""><img src=""https://d15k2d11r6t6rl.cloudfront.net/public/users/Integrators/BeeProAgency/1003843_988669/Poweredby-new.png"" style=""display: block; height: auto; border: 0; width: 140px; max-width: 100%;"" width=""140""></div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
					<table class=""row row-16"" align=""center"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f6f6f6;"">
						<tbody>
							<tr>
								<td>
									<table class=""row-content stack"" align=""center"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 800px;"" width=""800"">
										<tbody>
											<tr>
												<td class=""column column-1"" width=""100%"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; padding-bottom: 5px; padding-top: 5px; vertical-align: top; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;"">
													<table class=""text_block block-1"" width=""100%"" border=""0"" cellpadding=""10"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family: sans-serif"">
																	<div class style=""color: #9d1515; font-size: 12px; font-family: Roboto, Tahoma, Verdana, Segoe, sans-serif; mso-line-height-alt: 14.399999999999999px; line-height: 1.2;"">
																		<p style=""margin: 0; font-size: 12px; text-align: center; mso-line-height-alt: 14.399999999999999px;""><span style=""color:#c0c0c0;font-size:16px;"">Changed your mind?<br>You can </span><span style=""font-size:16px;color:#0068a5;""><strong><a  href=""{_url}{application.email}"" target=""_blank"" title=""unsubscribe"" style=""text-decoration: underline; color: #911e1e;"" rel=""noopener"">unsubscribe</a></strong></span><span style=""color:#c0c0c0;font-size:16px;""><strong> </strong>at any time.</span></p>
																	</div>
																</div>
															</td>
														</tr>
													</table>
													<table class=""html_block block-2"" width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" role=""presentation"" style=""mso-table-lspace: 0pt; mso-table-rspace: 0pt;"">
														<tr>
															<td class=""pad"">
																<div style=""font-family:Roboto, Tahoma, Verdana, Segoe, sans-serif;text-align:center;"" align=""center""><div style=""height-top: 20px;"">&nbsp;</div></div>
															</td>
														</tr>
													</table>
												</td>
											</tr>
										</tbody>
									</table>
								</td>
							</tr>
						</tbody>
					</table>
				</td>
			</tr>
		</tbody>
	</table><!-- End -->
</body>

</html>
";

            try
            {
                // First, insert the application
                var insertedApplication = _Application.InsertApplication(application);

                // Check if the application was inserted successfully
                if (insertedApplication == null)
                {
                    return StatusCode(500, "Failed to insert application");
                }

                // Then, send the email
                await SendEmailAsync(emailTo, subject, body);

                return Ok(insertedApplication);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during email sending or application insertion
                return StatusCode(500, $"Failed to send email or insert application: {ex.Message}");
            }
        }

        public static async Task SendEmailAsync(string emailTo, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Gopetz", "demo@tltechnologies.net"));
            message.To.Add(new MailboxAddress("", emailTo));
            message.Subject = subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = body;

            message.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("demo@tltechnologies.net", "tltech$$2020");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }



      
    }
}
