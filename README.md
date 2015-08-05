Haxxor v0.9.0
=============
Haxxor is a simple encrpytion/decrpytion framework, which support multiple methods of encryption. More methods will be added as time goes on.

In some cases when a method is able to support decryption, the key and IV used to encrypt will also be included within the returned hash, such as with AES in the format "key;iv;cipher". This is done so later decryption is possible.

Haxxor is more meant as a tool to demo encryption/decryption, and is not meant to be 100% secure. Haxxor is however open-source, so you are able to to modify the underlying code to make it more secure.

Features
========
* Support for multiple methods of encryption and decryption
* Simple factory class to choose a method
* Ability to cycle a cipher through mutiple methods of decryption when method is unknown
* Can check if some plain text matches a passed cipher
* Comes with a console application
* Comes with a simple real-time encryption/decryption GUI

Supported Methods
=================
* SHA1, 256, 384, 512
* AES128, 256

More to come soon.

Examples
========
To use the GUI, open up the Haxxor.GUI application.

Console
-------
```shell
> Haxxor.Console encrypt aes128 "Hello, world!"
> Haxxor.Console decrypt aes128 "hash"
> Haxxor.Console list
> Haxxor.Console help
```

Code
----
To use the framework, reference the Haxxor.Framework in you project.
```C#
// Retrieve a module for AES128 encryption
var module = HaxxorFactory.GetByType(EncryptionType.AES128);

// Retrieve a module by hash
// (this is determined by the tag that Haxxor places on a hash, ie "AES128|<hash>"
var module = HaxxorFactory.GetByType(EncryptionType.AES128);
var hash = module.Encrypt("Hello, world!");
module = HaxxorFactory.GetByHash(hash);
Console.WriteLine(module.Decrypt(hash));

// Cycle a cipher through all possible decrpytion methods, if the original method is unknown
var attempts = HaxxorFactory.Cycle("some hash here");

// Each module also has a property informing if the method supports decryption
var module = HaxxorFactory.GetByType(EncryptionType.SHA1);
Console.WriteLine("Do I support decryption? " + module.IsDecryptable);

//Finally, you can validate some plain text matches a cipher
var module = HaxxorFactory.GetByType(EncryptionType.AES128);
var hash = module.Encrypt("Hello, world!");
var matches = module.Validate("Hello, world!", hash);
```