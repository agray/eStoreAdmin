# Readme

https://agray@github.com/agray/estoreadmin.git

  -  Overriding principles:  Don't Repeat Yourself.  Eliminate technical debt everywhere.  Keep maintainability as close to 10/10 as possible.  Refactor where necessary.

##RoadMap
  - Order Email:  Send email to manager users when order comes in based on user preferences.  Admin page for All, Daily, Weekly, DOW 
  - Entity Framework! Replace Object DataSources with Entity Datasources on CRUD pages.  Stick with Stored procs elsewhere
  - eStoreNPOI: Auto size columns
  - Perenial Job: Upgrade to latest stable version of JQuery UI (Andre)
  - Auditing of user actions. make sure every user action is logged.
  - WebDriver Selenium 2 Tests across all pages (Bruno)
  - Code to interfaces to make implementation pluggable (start with PayPal payment service).  Needs to be generic (Bruno)
  - Payment gateways. Add more. Stripe, Google checkout, Authorise.net, Braintree.  Code to generic interface (Bruno)
  - Manage and sell digital goods. Example: www.themodernman.com
  - Multistore!  Ability to define and independently manage multiple customer-facing stores out of the one database.
  - User definable layouts like http://goodsie.com/design.  .NET themes and web.config rewrite.
  - Make Add Size and Add Color like other Add pages
  - WYSIWYG Merchandise Admin Pages like Advanced and Setting pages
  - Fix Membership login in IE8
  - Fix Reports
  - Come up with neat ways of presenting data in management interface	
  - Remove tables for div like Departments/ManageDepartments across site (Andre nudge nudge)
  - Smush all images as part of build
  - Move Paypal code to windows Service and use InstallUtil
  - Image Scroll Admin from DTransAdmin
  - Image Scroller from DTrans
  - Update look of eStore to look more modern (Andre)
  - PayPal Refund in eStoreAdmin (Bruno)
  - Temporary password in eStore and eStoreAdmin
  - Performance: Make more use of ASP.NET Caching were possible
  - SQL DB deploy with WIX (see SQL @ http://wix.tramontana.co.hu/tutorial) (Bruno)

  - Deployment - Stay with WIX or Tarma InstallMate 7? or something else?
  - Security: Obsfuscation
  - Editions:  Basic, Professional, Enterprise.  Define different capabilities in each and implement
  - Fix EditCustomer Databinding
  - Combine eStore and eStoreAdmin into one Solution / one Repo.
  - Customer Account report Pass in Parameter
  - Fix Manage Orders GridView Pagination
  - Fix Online Customer in eStoreAdmin
  - Handle Authentication and Session Timeouts across site in a DRY way
  - HttpBrowserCapabilities Crawler.aspx
  - Inventory Email Notifications.  Send admin and manager users an email when a product stock level is getting low.
  - Review ASPdotNETStorefront
  - Review [dashCommerce](https://github.com/dashcommerce/dashcommerce)
  - Review [nopCommerce](www.nopcommerce.com/)
  - Review [Passport Style](http://www.passportstyle.com)
  - Review [goodsie](http://www.goodsie.com)
  - Manage Customer Accounts in eStoreAdmin
  - Improve Order Management
  - UI Feedback like a progress bar on Excel Import and Export (Andre)
  - CRUD Management for Store Locator with GoogleMaps integration
  - Store Locator preview from admin site
  - Postal Address Validation?