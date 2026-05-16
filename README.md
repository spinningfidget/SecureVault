SecureVault is a security-focused vault system designed to safely store, encrypt, manage, and retrieve sensitive data such as:
* API keys
* Credentials
* Tokens
* Secrets
* Encrypted files
* Configuration values

**Technology Stack**
| Component  | Technology            |
| ---------- | --------------------- |
| Language   | C#                    |
| Framework  | .NET / WinForms       |
| UI         | Windows Forms         |
| Encryption | AES-256               |
| Storage    | Local encrypted vault |
| Runtime    | .NET Desktop Runtime  |
  
**Built with a defense-in-depth philosophy, SecureVault prioritizes:**
* Strong cryptography
* Secure key handling
* Minimal attack surface
* Developer ergonomics
* Cross-platform usability

**Features**
* AES-256 encrypted vault storage
* Password-based key derivation
* Secure secret retrieval
* CLI-first workflow
* File encryption & decryption
* Tamper-resistant storage
* Environment variable integration
* Cross-platform support
* Modular architecture
* Extensible API design

**Security Model**
<br/>
SecureVault follows a zero-trust local encryption model:

* Secrets are encrypted before storage
* Plaintext data is never intentionally persisted
* Encryption keys are derived from user credentials
* Vault contents remain unreadable without the master key

**Cryptographic Principles**
  | Component       | Purpose                  |
| --------------- | ------------------------ |
| AES-256-GCM     | Authenticated encryption |
| PBKDF2 / Argon2 | Password key derivation  |
| Random IV/Nonce | Replay resistance        |
| HMAC/Auth Tags  | Integrity verification   |

**Application Architecture**

<img width="225" height="453" alt="image" src="https://github.com/user-attachments/assets/c4d2f4fe-9a6e-4991-9733-19a6999936f2" />

